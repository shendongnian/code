    public class TimeTaskViewModel : TimeDetailTask
    {
        public string TaskTypeDescription { get; set; }
        public TimeTaskViewModel(TimeDetailTask baseTask)
        {
            this.SomeProperty = baseTask.SomeProperty;
            // and so on
        }
    }
