    public class TaskDiplayModel
    {
        private string _priority = string.Empty;
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Priority
        {
           get { return _priority; }
           set { _priority = value; }
        }
        public TaskDisplayMode()
        {
          Description = string.Empty;
        }
    }
    public class TaskModifyModel : TaskDisplayMode
    {
      public int PriorityId { get; set; }
      public TaskModifyModel()
        :base()
      {
        PriorityId = 3;
      }
    }
