    class Person
    {
        public readonly string CannotBeAccessed;
        public  string CannotBeAccessed2 {get;}
        public void CannotBeAccessed3() { }
        public string CanBeAccessed;
        public string CanBeAccessed2 { set; }
    } 
