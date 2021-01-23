    [DebuggerDisplay("{Number} {Street,nq} {City,nq} {State,nq} {Zip}")]
    class Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public Address(int number, string street, string city, string state, int zip)
        {
            Number = number;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }
