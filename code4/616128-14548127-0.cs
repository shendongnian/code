    [Table("EntryTag")]
    public class EntryTag
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EntryTagId { get; set; }
    
        [Required]
        public virtual Entry Entry { get; set; }
    
        [Required]
        public virtual Tag Tag { get; set; }
    }
