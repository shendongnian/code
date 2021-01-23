        using System;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    namespace CanvasAnimation
    {
        /// <summary>
        /// Interaction logic for WorkerTimer.xaml
        /// </summary>
        public partial class WorkerTimer : Window
        {
            Timer timer;
            double directionDelta = 1.0;
            public WorkerTimer()
            {
                InitializeComponent();
                timer = new Timer(this.timerTick, this, 0, 1000 / 25); // 25 fPS timer
            }
            protected void timerTick(Object stateInfo)
            {
                //This is not a GUI thread!!!!
                //So we need to Invoke delegate with Dispatcher
                this.Dispatcher.Invoke(new MoveCanvasDelegate(this.moveCanvas), null);
            }
            protected delegate void MoveCanvasDelegate();
            protected void moveCanvas()
            {
                //This function must be called on GUI thread!!!
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
