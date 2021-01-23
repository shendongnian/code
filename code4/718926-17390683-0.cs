     class Class1
    {
        public string firstName;
        public string lastName;
        public Class1 FirstName(string firstname)
        {
            this.firstName = firstname;
            return this;
        }
        public Class1 LastName(string lastname)
        {
            this.lastName = lastname;
            return this;
        }
    }
