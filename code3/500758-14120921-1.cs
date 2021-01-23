    public void Process(ScheduledTaskContext context) {
            if (context.Task.TaskType == TaskType) {
                try {
    
                    var x = "kuku";
    
                } catch (Exception e) {
                    this.Logger.Error(e, e.Message);
                } finally {
    
                    this.ScheduleNextTask();
                }
            }
        }
    
        private void ScheduleNextTask() {
            var date = _clock.UtcNow.AddSeconds(5);
            _taskManager.DeleteTasks(null, a => a.TaskType == TaskType);
            _taskManager.CreateTask(TaskType, date, null);
        }
