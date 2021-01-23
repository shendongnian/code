    private class Traffic {
        public int Id { get; set; }
        public string Owner { get; set; }
        public DateTime CallTime { get; set; }
    }
    private class TrafficEquaityComparer : IEqualityComparer<Traffic> {
        public bool Equals(Traffic x, Traffic y) {
                return x.Owner == y.Owner;
        }
        public int GetHashCode(Traffic obj) {
            return obj.Owner.GetHashCode();
        }
    }
    private static TrafficEquaityComparer TrafficEqCmp = new TrafficEquaityComparer();
    private Traffic[] src = new Traffic[]{
       new Traffic{Id = 1, Owner = "A", CallTime = new DateTime(2012,1,1)},  // oldest
       new Traffic{Id = 2, Owner = "A", CallTime = new DateTime(2012,2,1)},
       new Traffic{Id = 3, Owner = "A", CallTime = new DateTime(2012,3,1)},
       new Traffic{Id = 4, Owner = "B", CallTime = new DateTime(2011,3,1)},
       new Traffic{Id = 5, Owner = "B", CallTime = new DateTime(2011,1,1)},   //oldest
       new Traffic{Id = 6, Owner = "B", CallTime = new DateTime(2011,2,1)},
    };
    [TestMethod]
    public void GetMinCalls() {
        var results = src.GroupBy(ts => ts, TrafficEqCmp)
                         .Select(grp => new { Id = grp.Key.Id, 
                                              Owner = grp.Key.Owner, 
                                              CallTime = grp.Min(g => g.CallTime) 
                                             });
    }
