    public class Program
    {
        private Timer timer;
        public Program()
        {
           InitializeTimer();
           StartTimerFromBeginning();
        }
        public void MethodThatShouldBeCalledFrequently()
        {
           StartTimerFromBeginning();
        }
        public event EventHandler MethodNotCalledForFiveSeconds;
        private void InitializeTimer()
        {
           timer = new Timer(5000);
           timer.Elapsed += HandleTimerElapsed;
        }
        private void StartTimerFromBeginning()
        {
           timer.Stop();
           timer.Start();
        }
        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
           MethodNotCalledForFiveSeconds(this, EventArgs.Empty);
        }
    }
