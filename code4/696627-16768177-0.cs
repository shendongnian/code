    private void ExecuteSubTasks()
    {
        var tasks = new Task[]
            {
                new Task(() => Console.WriteLine("SubTask1 executed.")),
                new Task(() => Console.WriteLine("SubTask2 executed.")),
                new Task(() => Console.WriteLine("SubTask3 executed.")),
            };
    
        foreach (var task in tasks)
            task.Start();
        Task.WaitAll(tasks);
    }
    
    private void Start()
    {
        var mainTask = Task.Factory.StartNew(() => ExecuteSubTasks())
            .ContinueWith((prev) =>
            {
                ExecuteSubTasks();
                this.Invoke((MethodInvoker)delegate { MessageBox.Show("Completed."); });
            });
    }
