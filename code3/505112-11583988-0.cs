    var person = JsonConvert.DeserializeObject<Person>(json);
    class Person
    {
        [JsonProperty("StreetAddress")]
        private string _StreetAddress { get; set; }
        [JsonProperty("City")]
        private string _City { get; set; }
        [JsonProperty("Zip")]
        private string _ZipCode { get; set; }
        public string Name { get; set; }
        public Address Address
        {
            get
            {
                return new Address() { City = _City, StreetAddress = _StreetAddress, ZipCode = _ZipCode };
            }
        }
    }
    class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
