    public static Log
    {
        private static List<string> _messages = new List<string>();
    
        public static Write(string message)
        {
            _messages.Add(message);
        }
    
        public static IEnumerable<string> Messages 
        { 
           get { return _messages; }
        }
    }
