    public class MyBox : TextBox
    {
        private readonly DispatcherTimer timer;
        public MyBox()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += OnTimerTick;
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            // do something here
        }
    }
