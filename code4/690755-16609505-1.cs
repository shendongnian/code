    var place = new Place
    {
      Name = "The Old Blue Last",
      URL = "old-blue-last-pub",
      Address = "38 Great Eastern St",
      City = "London",
      PostCode = "EC2A 3ES",
      Website = "www.theoldbluelast.com",
      Phone = "123 456 789",  // updated number
      About = "Pub of Vice Magazine",
      Image = "noimage.png",
      Tag = db.Tags.Single(t => t.Name == "Bakery")
    };
    db.Places.AddOrUpdate(p => p.Name, place);
    db.SaveChanges();
