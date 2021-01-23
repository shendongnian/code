     private class People
     {
          public string Name;
          public IEnumerable<Order> Orders;
     }
     private class Order
     {
          public int OrderId;
          public int Amount;
     }
     public void PrintPeople()
     {
          IEnumerable<People> crecords = new[] {
               new People{ 
                    Name = "XYZ", 
                    Orders = new Order[] 
                    { 
                        new Order{ OrderId = 1, Amount = 340 }, 
                        new Order{ OrderId = 2, Amount = 100 }, 
                        new Order{ OrderId = 3, Amount = 200 } 
                    } 
               },
               new People{ 
                    Name = "ABC", 
                    Orders = new Order[] 
                    { 
                        new Order{ OrderId = 11, Amount = 900 }, 
                        new Order{ OrderId = 12, Amount = 800 }, 
                        new Order{ OrderId = 13, Amount = 700 } 
                    } 
                }
            };
            crecords = crecords.OrderBy(record => record.Name);
            crecords.ToList().ForEach(
                    person =>
                    {
                        person.Orders = person.Orders
                              .Where(order => order.Amount%100 == 0)
                              .OrderByDescending(t => t.Amount)
                              .Take(2);
                    }
                );
            foreach (People record in crecords)
            {
                Console.WriteLine(record.Name);
                foreach (var order in record.Orders)
                {
                    Console.WriteLine("-->" + order.Amount.ToString());
                }
            }
        }
