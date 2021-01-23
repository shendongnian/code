    public class Version
    {
        [Column("Version")]
        public string FullVersion { get; set; } // assign minor and major here
        [NotMapped]
        public string Major { get; set; }
        [NotMapped]
        public string Minor { get; set; }
        // ...
    }
