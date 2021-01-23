    class Record {
        public int  Id { get; set; }
        public DateTime Timestamp { get; set; }
    }
    private Record[] PositiveResponses = new[]{
        new Record{ Id =1 , Timestamp = new DateTime(2012,1,1)},
        new Record{ Id =1 , Timestamp = new DateTime(2012,1,2)},
        new Record{ Id =2 , Timestamp = new DateTime(2012,1,3)},
        new Record{ Id =2 , Timestamp = new DateTime(2012,1,5)}, // latest for id 2
        new Record{ Id =3 , Timestamp = new DateTime(2012,1,8)},
        new Record{ Id =4 , Timestamp = new DateTime(2012,1,8)}  // latest for Id 4
    };
    private Record[] NegativeResponses = new[]{
        new Record{ Id =1 , Timestamp = new DateTime(2012,1,1)},
        new Record{ Id =1 , Timestamp = new DateTime(2012,1,3)}, // latest for Id 1
        new Record{ Id =2 , Timestamp = new DateTime(2012,1,4)},
        new Record{ Id =3 , Timestamp = new DateTime(2012,1,9)}  // latest for id 3
    };
        
    [TestMethod]
    public void GetLatest() {
        var results = PositiveResponses.Select(r => new {
                                                         Id = r.Id, 
                                                         Timestamp = r.Timestamp, 
                                                         Type = "Pos"
                                                     })
                                        .Union(
                      NegativeResponses.Select(r => new {Id = r.Id, 
                                                         Timestamp = r.Timestamp,
                                                         Type = "Neg"}))
                      .GroupBy(r => r.Id)
                      .Select(grp => grp.OrderByDescending(r => r.Timestamp).First());
        }
