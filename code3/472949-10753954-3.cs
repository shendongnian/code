    public class ScheduledTask
    {
        private IFoo _foo;
        private readonly StartStopTask _startstop;
        public ScheduledTask(IFoo foo)
        {
            _foo = foo;
            _startstop = new StartStopTask(() => Run());
        }
        public void Start()
        {           
            _startstop.Start();
        }
        public void Stop(TimeSpan timeout)
        {
            _startstop.Stop(timeout);
        }
        private void Run(){ // Do some work }
    }
