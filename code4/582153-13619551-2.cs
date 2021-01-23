    public class Task
    {
        public Task()
        { 
        }
        public Task(String tName, Int32 iInterval, Int16 iPriority)
        {
            this.taskName = tName;
            this.nextInterval = iInterval;
            this.priority = iPriority;
        }
        private String taskName = String.Empty;
        public String TaskName
        {
            get
            {
                return this.taskName;
            }
            set
            {
                this.taskName = value;
            }
        }
        private Int32 nextInterval = 1;
        public Int32 NextInterval
        {
            get
            {
                return this.nextInterval;
            }
            set
            {
                this.nextInterval = value;
            }
        }
        private Int16 priority = 1;
        public Int16 Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }
    }
