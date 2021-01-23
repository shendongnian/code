    class Class1
    {
        private string name, jobTitle, address;
        public Class1(string name, string title) 
            : this(name, title, "my default address") {}
        public Class1(string name, string jobTitle, string address)
        {
            this.name = name;
            this.jobTitle = jobTitle;
            this.address = address;
        }
    }
