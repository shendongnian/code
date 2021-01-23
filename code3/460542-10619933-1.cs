                try
                {
                    ctx.SaveChanges();
                    // will throw an exception because customer 1 is already in DB
                }
                catch (DbUpdateException e)
                {
                    ctx.Entry(customer).State = EntityState.Detached;
                    // customer is now detached from context and
                    // won't be saved anymore with the next SaveChanges
                    // create new object adn attach this to the context
                    var customer2 = new Customer { Id = 2, Name = "Y" };
                    ctx.Customers.Add(customer2);
                    ctx.SaveChanges();
                    // no exception
                }
