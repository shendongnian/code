    internal static class SchedulerDefaults
    {
        internal static IScheduler AsyncConversions 
        { get { return DefaultScheduler.Instance; }}
        internal static IScheduler ConstantTimeOperations 
        { get { return ImmediateScheduler.Instance; }}
        internal static IScheduler Iteration 
        { get { return CurrentThreadScheduler.Instance; }}
        internal static IScheduler TailRecursion 
        { get { return ImmediateScheduler.Instance; }}
        internal static IScheduler TimeBasedOperations 
        { get { return DefaultScheduler.Instance; }}
    }
