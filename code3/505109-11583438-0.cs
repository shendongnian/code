    class Person
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [ScriptIgnore]
        public Address Address { get {return new Address(){StreetAddress = this.StreetAddress,
                                                           City = this.City,
                                                           ZipCode = this.ZipCode} } }
    }
