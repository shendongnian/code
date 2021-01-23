        public static class ExtensionMethods
        {
            private static readonly ConcurrentDictionary<WeakReference<Task>, object> TaskNames = new ConcurrentDictionary<WeakReference<Task>, object>();
            public static void _Tag(this Task pTask, object pTag)
            {
                if (pTask == null) return;
                var weakReference = ContainsTask(pTask) ?? new WeakReference<Task>(pTask);
                TaskNames[weakReference] = pTag;
            }
            public static void _Name(this Task pTask, string name)
            {
                _Tag(pTask, name);
            }
            public static object _Tag(this Task pTask)
            {
                var weakReference = ContainsTask(pTask);
                if (weakReference == null) return null;
                return TaskNames[weakReference];
            }
            public static object _Name(this Task pTask)
            {
                return (string)_Tag(pTask);
            }
            private static WeakReference<Task> ContainsTask(Task pTask)
            {
                foreach (var kvp in TaskNames.ToList())
                {
                    WeakReference<Task> weakReference = kvp.Key;
                    if (!weakReference.TryGetTarget(out var taskFromReference))
                    {
                        TaskNames.TryRemove(weakReference, out _);
                        //TaskNames.TryRemove(out ); //Keep the dictionary clean.
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
