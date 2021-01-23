    var intTask1 = Task.Run(() => 1);
    var intTask2 = Task.Run(() => 2);
    var intTasks = new List<Task<int>> { intTask1, intTask2 };
    var intExecutor = new TaskExecutor<int>();
    await intExecutor.ExecuteTasks(intTasks);
    var stringTask1 = Task.Run(() => "foo");
    var stringTask2 = Task.Run(() => "bar");
    var stringTasks = new List<Task<string>> { stringTask1, stringTask2 };
    var stringExecutor = new TaskExecutor<string>();
    await stringExecutor.ExecuteTasks(stringTasks);
 ..................................
    class TaskExecutor<T>
    {
        public async Task ExecuteTasks(IEnumerable<Task<T>> tasks)
        {
            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
    }
