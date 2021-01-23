    public static IList<Task> GetAllTasks()
        {
            List<Task> taskList = new List<Task>();
            foreach (TaskSet.TaskRow r in _taskSet.Task.AsEnumerable())
                taskList.Add(new WorkTimeTable.Model.Task()
                                 {
                                     Name = r.Name, Description = r.Description, ToDateTime = r.ToDate, FromDateTime = r.FromDate, TotalTime = r.TimeSpan
                                 });
            return taskList;
        }
