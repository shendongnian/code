    public class CSVViewModel
    {
        // User proper names for your CSV columns, these are just examples...   
        
        [Required]
        public int Column1 { get; set; } 
        [Required]
        [StringLength(30)]
        public string Column2 { get; set; }
    }
