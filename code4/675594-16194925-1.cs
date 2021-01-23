    public sealed class TestSchedulerProvider : ISchedulerProvider
    {
        private readonly TestScheduler _dispatcher = new TestScheduler();
        private readonly TestScheduler _concurrent = new TestScheduler();
        private readonly TestScheduler _longRunning = new TestScheduler();
        private readonly TestScheduler _periodic = new TestScheduler();
        IScheduler ISchedulerProvider.Dispatcher
        {
            get { return _dispatcher; }
        }
        public TestScheduler Dispatcher
        {
            get { return _dispatcher; }
        }
        IScheduler ISchedulerProvider.Concurrent
        {
            get { return _concurrent; }
        }
        public TestScheduler Concurrent
        {
            get { return _concurrent; }
        }
        ISchedulerLongRunning ISchedulerProvider.LongRunning
        {
            get { return _longRunning.AsLongRunning(); }
        }
        public TestScheduler LongRunning
        {
            get { return _longRunning; }
        }
        ISchedulerPeriodic ISchedulerProvider.Periodic
        {
            get { return _periodic.AsPeriodic(); }
        }
        public TestScheduler Periodic
        {
            get { return _periodic; }
        }
    }
