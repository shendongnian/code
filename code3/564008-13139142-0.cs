        class TestClass1
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        List<Country> countries = new List<Country>();
        TestClass1[] arrays = new TestClass1[30];
        countries.Where(x => arrays.Select(y => y.Id).Contains(x.Id)).ToList();
