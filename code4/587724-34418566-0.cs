    public static class TaskExtensions
    {
        private static readonly Dictionary<WeakReference<Task>, object> TaskNames = new Dictionary<WeakReference<Task>, object>(); 
        public static void Tag(this Task pTask, object pTag)
        {
            if (pTask == null) return;
            var weakReference = ContainsTask(pTask);
            if (weakReference == null)
            {
                weakReference = new WeakReference<Task>(pTask);
            }
            TaskNames[weakReference] = pTag;
        }
        public static object Tag(this Task pTask)
        {
            var weakReference = ContainsTask(pTask);
            if (weakReference == null) return string.Empty;
            return TaskNames[weakReference];
        }
        private static WeakReference<Task> ContainsTask(Task pTask)
        {
            foreach (var kvp in TaskNames.ToList())
            {
                var weakReference = kvp.Key;
                Task taskFromReference;
                if (!weakReference.TryGetTarget(out taskFromReference))
                {
                    TaskNames.Remove(weakReference); //Keep the dictionary clean.
                    continue;
                }
                if (pTask == taskFromReference)
                {
                    return weakReference;
                }
            }
            return null;
        }
    }
