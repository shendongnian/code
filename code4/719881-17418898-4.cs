    public class Version
    {
        public string FullVersion 
        { 
           get { return String.Format("{0}.{1}", Major, Minor); }           
        }
        public int Major { get; set; }
        public int Minor { get; set; }
    
        public static Version Parse(string s)
        {
            var parts = s.Split('.');
    
            return new Version {
                Major = Int32.Parse(parts[0]),
                Minor = Int32.Parse(parts[1])
            };
        }
    
        public override string ToString()
        {
            return FullVersion;
        }
    }
