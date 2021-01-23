    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    namespace CanvasAnimation
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            DispatcherTimer uiTimer;
            double directionDelta = 1.0;
            public MainWindow()
            {
                InitializeComponent();
                uiTimer = new DispatcherTimer(); //This timer is created on GUI thread.
                uiTimer.Tick += new EventHandler(uiTimerTick);
                uiTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000/25); // 25 ticks per second
                uiTimer.Start();
            }
            private void uiTimerTick(object sender, EventArgs e)
            {
                double currentLeft = Canvas.GetLeft(Kwadracik);
                if (currentLeft < 0)
                {
                    directionDelta = 1.0;
                }
                else if (currentLeft > 80)
                {
                    directionDelta = -1.0;
                }
                currentLeft += directionDelta;
                Canvas.SetLeft(Kwadracik, currentLeft);
            }
        }
    }
