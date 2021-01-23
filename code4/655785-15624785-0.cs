    public class MyBox : TextBox
    {
        private DispatcherTimer timer;
        public MyBox()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += timer_Tick;
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            // do something here
        }
    }
