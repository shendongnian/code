    public class TimeController
    {
        private static readonly TimeSpan TimeSpan = new TimeSpan(0, 0, 1);
        private static int _time;
        protected static readonly DispatcherTimer Timer = new DispatcherTimer();
        protected static readonly DispatcherTimer BeeperTimer = new DispatcherTimer();
        protected static readonly Stopwatch StopWatch = new Stopwatch();
        protected static Label TimerLabel;
        protected static Button StartButton;
        internal static int Time { get { return _time; } set { _time = value; ExtractAndUpdate(); } }
        internal static bool Countdown { get; set; }
        /// <summary>
        /// Static constructor
        /// </summary>
        static TimeController()
        {
            BeeperTimer.Interval = TimeSpan;
            BeeperTimer.Tick += BeeperTick;
            Timer.Interval = TimeSpan;
            Timer.Tick += TimerTick;
        }
        /// <summary>
        /// Timer tick event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TimerTick(object sender, EventArgs e)
        {
            if (Countdown)
                if (Time > 0)
                {
                    ExtractAndUpdate();
                    Time -= 1;
                }
                else
                {
                    StopRunning();
                    BeeperTimer.Start();
                }
            else
                ExtractAndUpdate();
        }
        /// <summary>
        /// Start timer and stopwatch
        /// </summary>
        protected static void StartRunning()
        {
            Timer.Start();
            StopWatch.Start();
            StartButton.Content = Labels.Pause;
        }
        /// <summary>
        /// Stop timer and stopwatch
        /// </summary>
        protected static void StopRunning()
        {
            Timer.Stop();
            StopWatch.Stop();
            StartButton.Content = Labels.Start;
        }
        /// <summary>
        /// Beeper event method and label blinking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BeeperTick(object sender, EventArgs e)
        {
            TimerLabel.Visibility = TimerLabel.Visibility.Equals(Visibility.Hidden) ? Visibility.Visible : Visibility.Hidden;
            Console.Beep();
        }
        /// <summary>
        /// Extract time and update label
        /// </summary>
        private static void ExtractAndUpdate()
        {
            var elapsed = Countdown ? ConvertToTimeSpan() : StopWatch.Elapsed;
            UpdateTimeLabel(elapsed);
        }
        /// <summary>
        /// Convert int to TimeSpan
        /// </summary>
        /// <returns></returns>
        internal static TimeSpan ConvertToTimeSpan()
        {
            var hours = Time / 3600;
            var minutes = (Time % 3600) / 60;
            var seconds = Time % 60;
            return new TimeSpan(hours, minutes, seconds);
        }
        /// <summary>
        /// Update label with data and change color
        /// </summary>
        /// <param name="elapsed"></param>
        protected static void UpdateTimeLabel(TimeSpan elapsed)
        {
            TimerLabel.Foreground = Brushes.Black;
            var time = String.Format(CultureInfo.CurrentCulture, "{0:00h} {1:00m} {2:00s}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            if (Countdown && elapsed.TotalMinutes < 1)
                TimerLabel.Foreground = Brushes.Red;
            TimerLabel.Content = time;
        }
    }
