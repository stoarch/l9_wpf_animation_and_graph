using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace l9_Graphics_and_animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer;
        public MainWindow()
        {
            InitializeComponent();

            timer = new Timer(OnTimer,null, 0, 13);

            var player = new MediaPlayer();
            player.Open(new Uri("lake.mp4", UriKind.Relative));
            var drawing = new VideoDrawing();
            drawing.Rect = new Rect(0, 0, 50, 50);
            drawing.Player = player;
            videoBrush.Drawing = drawing;
            player.Play();

            var animLeft = new DoubleAnimation();
            animLeft.From = 0;
            animLeft.To = 100;
            animLeft.Duration = TimeSpan.Parse("0:0:5");
            animLeft.RepeatBehavior = RepeatBehavior.Forever;
            animLeft.AutoReverse = true;

            title.BeginAnimation(LeftProperty, animLeft);

            
        }
        
        void OnTimer(object state)
        {
            rotation.Dispatcher.Invoke(RotateOkButton);            
        }

        private void RotateOkButton()
        {
            rotation.Angle += .3;
            //shadow.Direction += .3;
            ___gradientRotation.Angle += 0.3;
        }
    }
}
