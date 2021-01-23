     var person = new Person { ... }
     var country = new Country { Id = ... }
     person.Country = country;
     context.Attach(country);
     context.SaveChanges();
