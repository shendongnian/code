    public class Job
    {
        private bool state;
        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnStateChanged();
                }
            }
        }
        private void OnStateChanged()
        {
            if (state) // or you could use enum for state
                Run();
            else
                Stop();
        }
        private void Run()
        {
            // run
        }
        private void Stop()
        {
            // stop
        }
    }
