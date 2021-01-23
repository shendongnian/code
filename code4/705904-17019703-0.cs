            // Create list of tasks
            System.Threading.Tasks.Task[] tasks = new System.Threading.Tasks.Task[2];
            // First task
            var firstTask = System.Threading.Tasks.Task.Factory.StartNew(() => Console.Write("First method call"), TaskCreationOptions.LongRunning);
            tasks[0] = firstTask;
            // Second task
            var secondTask = System.Threading.Tasks.Task.Factory.StartNew(() => Console.Write("Second method call"), TaskCreationOptions.LongRunning);
            tasks[1] = secondTask;
            // Launch all
            System.Threading.Tasks.Task.WaitAll(tasks);
