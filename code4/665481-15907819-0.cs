    public class Note
    {
        [Key]
        [ForeignKey("UserProfile"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId{ get; set; }
        public virtual UserProfile UserProfile { get; set; }
 
        public string Description { get; set; }
    }
