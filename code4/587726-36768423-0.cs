        readonly Queue<Task> _taskqueue = new Queue<Task>();
        private readonly object _queueLock = new object();
        public Task RunTask(Action action)
        {
            //incoming task must be queued as soon as it arrives
            var inComingTask = new Task(action);
            lock (_queueLock)
            {
                _taskqueue.Enqueue(inComingTask);
            }
            return Task.Factory.StartNew(() =>
            {
                //run all actions one by one..
                while (true)
                {
                    lock (_queueLock) //only one task must be performed at a 
                    {
                        if (_taskqueue.Count == 0) return;
                        var outTask = _taskqueue.Dequeue();
                        outTask.Start();
                        outTask.Wait();
                        Console.WriteLine("done....");
                    }
                }
            });
        }
    }
