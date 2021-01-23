    class Person
    {
        private String name;
    
        public Person(String name)
        {
            this.Name = Name
        }
    
        public String Name
        {
            get {
                return this.name;
            }
            set {
                if(String.IsNullOrEmpty(value)) return;
                this.name = value;
            }
        }
    }
