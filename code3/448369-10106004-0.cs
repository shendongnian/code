    public static class TestIdGenerator
    {
        private static readonly Lazy<DateTime> _testId = new Lazy<DateTime>(() => DateTime.Now);
        public static DateTime TestId
        {
            get { return _testId.Value; }
        }
    }
