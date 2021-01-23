    public class Note
    {
        public int NoteID {get; set;}
        public string Description {get; set;}
        public int? TaskId {get; set;} // Notice the int is nullable
        public virtual Task {get; set;}
    }
    public class Task
    {
        public int TaskID {get; set;}
        public TaskTypeEnum TaskType {get; set;}
        public string Description {get; set;}
        public virtual ICollection<Note> Notes {get; set;}
    }
