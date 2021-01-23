    public class Program
    {
        private Timer timer;
        public Program()
        {
           StartTimerFromBeginning();
        }
        public void MethodThatShouldBeCalledFrequently()
        {
           StartTimerFromBeginning();
        }
        public event EventHandler MethodNotCalledForFiveSeconds;
        private void StartTimerFromBeginning()
        {
           timer.Stop();
           timer = new Timer(5000);
           timer.Elapsed += HandleTimerElapsed;
        }
        private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
           MethodNotCalledForFiveSeconds(this, EventArgs.Empty);
        }
    }
