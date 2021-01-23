    using(var db = new OurDataContext(connString))
    {
      var tab = db.Coordinates;
      tab.InsertOnSubmit(new Coordinates{X=3,Y=10});
      tab.InsertOnSubmit(new Coordinates{X=5,Y=7});
      tab.InsertOnSubmit(new Coordinates{X=2,Y=15});
      db.SubmitChanges();
    }
