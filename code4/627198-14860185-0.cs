    public class Stock
    {
        public int Id;
        public int LocationId;
        public int Quantity;
    }
            
    static void Main(string[] args)
    {
        var list = new List<Stock>()
            {
                new Stock(){ Id = 1, LocationId = 1, Quantity = 20},
                new Stock(){ Id = 1, LocationId = 2, Quantity = 30},
                new Stock(){ Id = 1, LocationId = 1, Quantity = 30},
                new Stock(){ Id = 2, LocationId = 2, Quantity = 20},
                new Stock(){ Id = 1, LocationId = 2, Quantity = 30},
                new Stock(){ Id = 1, LocationId = 1, Quantity = 100},
    
            };
    
        var grouped = list.GroupBy(c => new {Id = c.Id, LocationId = c.LocationId})
                .Select(g => new 
                     { 
                          Id = g.Key.Id, 
                          LocationId = g.Key.LocationId, 
                          Quantity = g.Sum(a => a.Quantity) 
                      });
        foreach(var group in grouped.OrderBy(c => c.Id))
        {
            Console.WriteLine("Id:{0} - LocationId:{1} - Quantity:{2}", group.Id, 
                     group.LocationId, group.Quantity);
        }
    }
