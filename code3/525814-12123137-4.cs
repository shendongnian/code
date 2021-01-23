    private static IEnumerable<Coordinate> ProduceRandomCoordinates(int num)
    {
      var rnd = new Random();
      while(num-- > 0)
        yield return new Coordinate{X=rnd.Next(-100, 101), Y=rnd.Next(-100, 101)};
    }
    
    using(var db = new OurDataContext(connString))
    {
      var tab = db.Coordinates;
      tab.InsertAllOnSubmit(ProduceRandomCoordinates(500));
      db.SubmitChanges();
    }
