    public class NamedTaskSchedular
    {
        private static readonly ConcurrentDictionary<string, NamesTask> NamedTaskDictionary = new ConcurrentDictionary<string, NamesTask>();
        public static Task RunNamedTask(string name, Action action)
        {
            if (NamedTaskDictionary.ContainsKey(name))
            {
                return NamedTaskDictionary[name].RunTask(action);
            }
            var task = new NamesTask();
            NamedTaskDictionary[name] = task;
            return task.RunTask(action);
        }
    }
