        private void FireAndForget()
        {
            var tasks = new Task[2];
            tasks[0] = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                throw new Exception("boo");
            });
            tasks[1] = tasks[0].ContinueWith((t) =>
            {
                throw new Exception("nested boo", tasks[0].Exception);
            }, TaskContinuationOptions.OnlyOnFaulted);
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ex)
            {
                throw new Exception("Task", ex);
            }
        }
