    public class Note
    {        
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public virtual UserProfile User { get; set; }
    }
    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            this.Notes = new HashSet<Note>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Note> Notes{ get; set; }
    }
