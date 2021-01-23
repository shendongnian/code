        public static void serializercustom(Newtonsoft.Json.JsonSerializer serialiser)
        {
            serialiser.Converters.Add(new EmailConverterTest());
        }
        public static void TestCustomer()
        {
            using (var documentStore = new DefaultDocumentStore())
            {
                documentStore.ConnectionStringName = Properties.Settings.Default.SandBoxConnection;
                documentStore.Initialize();
                documentStore.Conventions.CustomizeJsonSerializer = new Action<Newtonsoft.Json.JsonSerializer>(serializercustom);
                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    Email = new EmailAddress("testemail@gmail.com")
                };
                // Save and retrieve the data
                using (var session = documentStore.OpenSession())
                {
                    session.Store(customer);
                    session.SaveChanges();
                }
                using (var session = documentStore.OpenSession())
                {
                    var addressToQuery = customer.Email;
                    var result = session.Query<Customer>(typeof(CustomerEmailIndex).Name).Customize(p => p.WaitForNonStaleResults()).Where(p => p.Email == addressToQuery);
                    Console.WriteLine("Number of Results {0}", result.Count()); // This always seems to return the matching document
                }
            }
        } 
