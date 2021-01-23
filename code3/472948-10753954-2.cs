    public class ScheduledTask : StartStopTask
    {
        private IFoo _foo;
        public ScheduledTask(IFoo foo)
            : base(() => Run())
        {
            _foo = foo;
        }
        private void Run(){ // Do some work }
    }
