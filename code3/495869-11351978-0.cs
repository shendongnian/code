    public class Child
    {
        [Key]
        public int ChildId { get;  set; }
        public int SomeOtherId { get; set; }
        [Required]
        public string ChildName { get; set; }
    }
