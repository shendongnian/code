    private class SomeEntry {
        public int TranCount { get; set; }
        public int RejCount { get; set; }
        public DateTime Timestamp { get; set; }
    }
    private List<SomeEntry> Entries = new List<SomeEntry>() {
            new SomeEntry{TranCount = 1, RejCount = 11, Timestamp = new DateTime(2012,1,1)},
            new SomeEntry{TranCount = 2, RejCount = 12, Timestamp = new DateTime(2012,1,2)},
            new SomeEntry{TranCount = 3, RejCount = 13, Timestamp = new DateTime(2012,1,3)},
            new SomeEntry{TranCount = 4, RejCount = 14, Timestamp = new DateTime(2012,1,4)},
            new SomeEntry{TranCount = 5, RejCount = 15, Timestamp = new DateTime(2012,1,5)},
            new SomeEntry{TranCount = 6, RejCount = 16, Timestamp = new DateTime(2012,1,6)},
    };
    private static SomeEntry Aggregate(SomeEntry agg, SomeEntry entry) {
            agg.TranCount += entry.TranCount;
            agg.RejCount += entry.RejCount;
            return agg;
    }
    [TestMethod]
    public void AggregateFirstThree() {
       var startDate = new DateTime(2012,1,1);
       var endDate = new DateTime(2012,1,3);
       var aggregate = new SomeEntry();
       Entries.Where(entry => entry.Timestamp >= startDate && entry.Timestamp <= endDate).Aggregate(aggregate, Aggregate);
       Assert.AreEqual(6, aggregate.TranCount);
       Assert.AreEqual(36, aggregate.RejCount);
    }
    [TestMethod]
    public void AggregateLastThree() {
        var startDate = new DateTime(2012, 1, 4);
        var endDate = new DateTime(2012, 1, 6);
        var aggregate = new SomeEntry();
        Entries.Where(entry => entry.Timestamp >= startDate && entry.Timestamp <= endDate).Aggregate(aggregate, Aggregate);
        Assert.AreEqual(15, aggregate.TranCount);
        Assert.AreEqual(45, aggregate.RejCount);
    }
