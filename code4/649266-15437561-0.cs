    [Table("PdfMeta")]
    public class Meta
    {
        [Key]
        public int Id { get; set; }
    
        [Column("TotalPages")]
        public int TotalPages { get; set; }
    
        [Column("PdfPath")]
        public string PdfUri { get; set; }
    
        [Column("ImagePath")]
        public string ImageUri { get; set; }
    
        [Column("SplittedPdfPath")]
        public string SplittedFolderUri { get; set; }
    }
