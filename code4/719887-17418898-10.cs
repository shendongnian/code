    public class Version
    {
        [Column("Version")]
        public string FullVersion 
        {
            get { return String.Format("{0}.{1}", Major, Minor); }
            set
            {
                var parts = value.Split('.');
                Major = parts[0];
                Minor = parts[1];
            }
        }
        [NotMapped]
        public string Major { get; set; }
        [NotMapped]
        public string Minor { get; set; }
        // ...
    }
