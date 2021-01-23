    public class Task
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual Useraccount Useraccount { get; set; }
    }
