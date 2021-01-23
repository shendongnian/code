            var mapping = new Dictionary<int, string> { };
            var tasks = new List<Task>();
            var task = new Task(() => Console.WriteLine("myNullTask"));
            tasks.Add(task);
            mapping.Add(task.Id, "myNullTask");
            foreach (var taskX in tasks)
            {
                string taskName;
                mapping.TryGetValue(taskX.Id, out taskName);
                Console.WriteLine(
                    $"Task Id: {taskX.Id}, " +
                    $"Task Name: {taskName}, " +
                    $"Task Status: {taskX.Status}");
            }
