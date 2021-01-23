    public static void FindTask(string taskName, string hostName, Expression<Func<T, bool>> filter, Action<Task> callback)
    {
        Regex regex = GetRegexForFindTask(taskName);
        using (TaskService ts = new TaskService(hostName))
        {
            foreach (Task t in ts.FindAllTasks(regex, true).Where(filter)) // Use linq filter here to narrow down the list of tasks
                if (t.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase))
                    callback(t);
        }
    }
