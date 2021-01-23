        public class Table
        {
            public string City { get; set; }
        
            public string Deposit { get; set; }
        
            public decimal Amount { get; set; }
        }
    
                 var list = new List<Table>
                               {
                                   new Table { City = "city1", Deposit = "new", Amount = 100 },
                                   new Table { City = "city1", Deposit = "new", Amount = 200 },
                                   new Table { City = "city2", Deposit = "old", Amount = 200 },
                                   new Table { City = "city2", Deposit = "old", Amount = 100 },
                                   new Table { City = "city2", Deposit = "new", Amount = 200 },
                                   new Table { City = "city3", Deposit = "new", Amount = 100 }
                               };
                //You can get all items by grouping with city and deposit in here.
                var result = (from c in list
                              group c by new {c.City,c.Deposit} into d
                              select new
                              {
                                  City = d.Key.City,
                                  Deposit = d.Key.Deposit,
                                  SumAmount = d.Sum(x => x.Amount)
                              });
    
                //If you want only new,
                var resultNew = result.Where(x => x.Deposit == "new");
                //If you want only old,
                var resultOld = result.Where(x => x.Deposit == "old");
