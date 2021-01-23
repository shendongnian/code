    private static void Main(string[] args)
    {
      List<MeasureStation> itemsToSort
        = new List<MeasureStation>()
            {
              new MeasureStation() {ID = 01, Name = "Bbbb"},
              new MeasureStation() {ID = 01, Name = "Aaaa"},
              new MeasureStation() {ID = 01, Name = "Cccc"}
            };
      List<MeasureStation> sortedItems = itemsToSort.OrderBy(x => x.Name).ToList();
      
      Console.WriteLine("******itemsToSort*****");
      foreach (var item in itemsToSort)
          Console.WriteLine(item.Name.ToString());
      Console.WriteLine("******sortedItems*****");
      foreach (var item in sortedItems)
            Console.WriteLine(item.Name.ToString());
      Console.ReadLine();
    }
