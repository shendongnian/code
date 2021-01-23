        private Dictionary<Guid, Task> _taskMap = new Dictionary<Guid, Task>();
        private void OnButton1Click(object sender, EventArgs eventArgs)
        {
            Task task = new Task(Guid.NewGuid());
            _taskMap.Add(task.Identity, task);
            task.DoWork += OnDoWork;
            task.Run();
        }
        private void OnButton2Click(object sender, EventArgs eventArgs)
        {
            Guid identity = _taskMap.Count > 0 ? _taskMap.First().Value.Identity : default(Guid);  // find some way to get the desired task
            Task task;
            if (_taskMap.TryGetValue(identity, out task))
            {
                task.DoWork -= OnDoWork;
                task.Stop();
                // do what you want with the timings
            }
        }
        private void OnDoWork(object sender, EventArgs eventArgs)
        {
		    // do work here
        }
