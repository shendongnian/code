        private Dictionary<Guid, TaskTracker> _taskMap = new Dictionary<Guid, TaskTracker>();
        private void OnButton1Click(object sender, EventArgs eventArgs)
        {
            TaskTracker taskTracker = new TaskTracker(Guid.NewGuid(), OnDoWork);
            _taskMap.Add(taskTracker.Identity, taskTracker);
            taskTracker.Run();
        }
		private void OnDoWork()
		{
		    // Do some work
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
		    // do what you want with the timings
		}
		
