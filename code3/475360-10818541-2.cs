    public partial class Window1 : Window
    {
        Button btn;
        Storyboard sb;
        public Window1()
        {
            btn = new Button();
            InitializeComponent();
            this.grid.Children.Add(btn);
            refreshPostIt();
        }
        private void refreshPostIt()
        {
            // Button btn; is defined somewhere else
            sb = new Storyboard();
            DoubleAnimation rotate = new DoubleAnimation();
            rotate.From = 0;
            rotate.To = 360;
            rotate.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform rt = new RotateTransform();
            btn.RenderTransformOrigin = new Point(0.5, 0.5);
            btn.RenderTransform = rt;
            Storyboard.SetTarget(rotate, btn);
            Storyboard.SetTargetName(rotate, btn.Name);
            Storyboard.SetTargetProperty(rotate, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            sb.Children.Add(rotate);
            sb.Begin(btn, true);
            BackgroundWorker asd = new BackgroundWorker();
            asd.DoWork += new DoWorkEventHandler(asd_DoWork);
            asd.RunWorkerCompleted += new RunWorkerCompletedEventHandler(asd_RunWorkerCompleted);
            asd.RunWorkerAsync();
        }
        void asd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sb != null)
            {
                sb.Stop(btn);
            }
        }
        void asd_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
        }
    }
