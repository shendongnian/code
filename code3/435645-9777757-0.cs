    static void Foo()
    {
        using (var db = new Context())
        {
            var c = new Country() {Name = "abc"};
            db.Country.AddOrUpdate(x => x.Name, c);
            var p = new Person()
            {
                Name = "me",
                CountryID = c.ID,
                Country = c 
            };
            db.Person.AddOrUpdate(x => x.Name, p);
            db.SaveChanges();
        }
    }
