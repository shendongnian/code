    public static class ScheduledTaskAccess
    {
        public static Task[] GetScheduledTasksForDebugger(TaskScheduler ts)
        {
            var mi = ts.GetType().GetMethod("GetScheduledTasksForDebugger", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mi == null)
                return null;
            return (Task[])mi.Invoke(ts, new object[0]);
        }      
    }
