    class Preferences
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }
    
        [MaxLength(30)]
        public string StationName { get; set; }
        [MaxLength(30)]
        public string MainDatabase { get; set; }
        [MaxLength(30)]
        public string DefaultSequence { get; set; }
    }
