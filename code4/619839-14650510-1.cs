    class public Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        private string zip_ = null;
        public string zip 
        { 
            get { return zip_; } 
            set
            {
                if (value.Length != 6) throw new Exception("Invalid zip code.");
                zip_ = value;
            }
        }
    
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
