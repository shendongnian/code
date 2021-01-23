    // Document
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    
        [InverseProperty("Document")]
        public virtual ICollection<Section> Sections { get; set; }
    }
    // Section
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Document")]
        public int DocumentId { get; set; }
    
        public virtual Document Document { get; set; }
    
        [InverseProperty("Section")]
        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
    // Paragraph
    public class Paragraph
    {
        [Key]
        public int Id { get; set; }
    
        [ForeignKey("Section")]
        public int SectionId { get; set; }
    
    
        public virtual Section Section { get; set; }
    }
