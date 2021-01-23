        private Dictionary<Guid, TaskTracker> _taskMap = new Dictionary<Guid, TaskTracker>();
        private void OnButton1Click(object sender, EventArgs eventArgs)
        {
            TaskTracker taskTracker = new TaskTracker(Guid.NewGuid(), OnDoWork);
            _taskMap.Add(taskTracker.Identity, taskTracker);
            taskTracker.Start();
        }
        private void OnDoWork(CancellationToken token)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100); // Do some work, checking if cancel requested every once in a while
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
        }
        private void OnButton2Click(object sender, EventArgs eventArgs)
        {
            Guid identity = _taskMap.Count > 0 ? _taskMap.First().Value.Identity : default(Guid);  // find some way to get the desired task
            TaskTracker taskTracker;
            if (_taskMap.TryGetValue(identity, out taskTracker))
            {
                taskTracker.TaskExiting += OnTaskExiting;
                taskTracker.Stop();
            }
        }
        private void OnTaskExiting(object sender, EventArgs eventArgs)
        {
            TaskTracker taskTracker = (TaskTracker)sender;
            taskTracker.TaskExiting -= OnTaskExiting;
            _taskMap.Remove(taskTracker.Identity);
            Console.WriteLine("Time ellapsed for No partitioning at all version {0}ms , thread id was {1}", taskTracker.Stopwatch.ElapsedMilliseconds, Task.CurrentId);
        }
        private void OnButton3Click(object sender, EventArgs eventArgs)
        {
            Guid identity = _taskMap.Count > 0 ? _taskMap.First().Value.Identity : default(Guid);  // find some way to get the desired task
            TaskTracker taskTracker;
            if (_taskMap.TryGetValue(identity, out taskTracker))
            {
                taskTracker.TaskExiting += OnTaskExiting;
                taskTracker.Cancel();
            }
        }
