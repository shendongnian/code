     var bands = new List<Band>{
                         new Band { Name = "Bear vs Shark", Members = 4 },
                         new Band { Name = "Circa Survive", Members = 4 },
                         new Band { Name = "Damiera", Members = 3 }
     };
    bands.ForEach(x=> db.Bands.Add(x));
