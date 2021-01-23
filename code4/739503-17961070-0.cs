    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
    
        public Guid SourceKey { get; set; }
    
        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }
    
        [Column(TypeName = "ntext")]
        public string Value { get; set; }
    
        public string Tags { get; set; }
    
        public int OrganizationId { get; set; }
        public int ProjectId { get; set; }
    }
