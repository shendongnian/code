    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NoteID { get; set; }
    
        public Guid SourceKey { get; set; }
    
        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }
    
        [Column(TypeName = "ntext")]
        public string Value { get; set; }
    
        public string Tags { get; set; }
    
        public Guid OrganizationId { get; set; }
        public Guid ProjectId { get; set; }
    
    }
