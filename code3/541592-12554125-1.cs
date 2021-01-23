    public class Person
    {
        public string Last { get; set; }
        public string First { get; set; }
        public string FullName 
        { 
            get 
            { 
                return string.Format("{0}, {1}", First, Last); 
            } 
        }
    }
