    public class MyClass
    {
        private readonly Dictionary<String, Object> dictionary;
        
        public MyClass()
        {
            this.dictionary = new Dictionary<String, Object>();
            // Put the default values in the dictionary.
            this.dictionary["One"] = 10;
            this.dictionary["Another"] = "ABC";
        }
        
        public Object this[string name]
        {
            get { return this.dictionary[name]; }
            set { this.dictionary[name] = value; }
        }
    }
    
