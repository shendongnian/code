    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CustomIdName")]
        public Guid uuid { get; set; }
        public int active { get; set; }
    }
