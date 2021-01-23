    Class TaskViewModel
    {
        private Task task;
        public Boolean IsScheduled
        {
            get
            {
                return task.IsScheduled;
            }
            set
            {
                this.task.IsScheduled = value;
                this.task.IsScheduledDate = Date.Now();
            }
        TaskViewModel(Task task)
        {
           this.task = task;
        }
    }
