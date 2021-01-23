    public partial class FormWithStopwatch : Form
    {
        private readonly Stopwatch sw = new Stopwatch();
        // Auxiliary member to avoid doing TimeSpan.FromMilliseconds repeatedly
        private TimeSpan timerSpan;
    
        public void TimerStart()
        {
            timerSpan = TimeSpan.FromMilliseconds(timer.Interval);
            timer.Start();
            sw.Restart();
        }
    
        public TimeSpan GetRemaining()
        {
            return timerSpan - sw.Elapsed;
        }
    
        private void timer_Tick(object sender, EventArgs e)
        {
            // Do your thing
            sw.Restart();
        }
    }
    public partial class FormWithDateTime : Form
    {
        private DateTime timerEnd;
        public void TimerStart()
        {
            timerEnd = DateTime.Now.AddMilliseconds(timer.Interval);
            timer.Start();
        }
        public TimeSpan GetRemaining()
        {
            return timerEnd - DateTime.Now;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            // Do your thing
            timerEnd = DateTime.Now.AddMilliseconds(timer.Interval);
        }
    }
