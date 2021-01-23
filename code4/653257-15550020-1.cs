    public static Address BuildAddress(string name, int phrase = 10, string country = "USA")
    {
            var gen = new RandomGenerator();
    
            var address = Builder<AddressInfo>.CreateNew()
                .With(x => x.Name = name)
                .And((x => x.Address1 = gen.Int() + " " + gen.Phrase(10) + " Street"))
                .And(x => x.City = gen.Phrase(15))
                .And(x => x.StateOrProvince = gen.Phrase(2))
                .And(x => x.Country = country)
                .And(x => x.PostalCode = "32561").
                Build();
    
            return address;
    }
