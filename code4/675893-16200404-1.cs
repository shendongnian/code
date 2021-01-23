        for (int j = 0; j < 100; j++)
        {
            using (CustomersContext db = new CustomersContext())
            {
                Random r = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    Customer c = new Customer
                    {
                        Name = Guid.NewGuid().ToString(),
                        Age = r.Next(0, 100)
                    };
                    db.Customers.Add(c);
                }
                db.SaveChanges();
            }
        }
