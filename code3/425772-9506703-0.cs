    static void Main(string[] args)
    {
        var myItems = new List<MyItem>() 
        {
            new MyItem("A", 123, "23/02/2012"),
            new MyItem("A", 323, "22/02/2012"),
            new MyItem("B", 432, "23/02/2012"),
            new MyItem("B", 356, "22/02/2012")
            // ...
        };
        var grouped = from m in myItems
                      group m by m.Name into g
                      let maxTimestamp = g.Max(t => t.TimeStamp)
                      select new MyItem
                      {
                          Name = g.Key,
                          Value = g.First(f => f.TimeStamp == maxTimestamp).Value,
                          TimeStamp = maxTimestamp
                      };
         foreach (var gItem in grouped)
         {
            Console.WriteLine(gItem.Name + ", " + gItem.Value + ", " + gItem.TimeStamp);
         }
         Console.ReadLine();
    }
