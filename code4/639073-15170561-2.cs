    public class KeyWord
    {
        // Private field, only accessible within this class
        private static string[] _keywords = { "abstract", "as", "etc." };
    
        // Public Static Property, accessible wherever
        public static string[] Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
    }
