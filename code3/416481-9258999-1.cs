    private static ActivityLog Aggregate(ActivityLog agg, ActivityLog entry) {
        agg.TranCount += entry.TranCount;
        agg.ReqCount += entry.ReqCount;
        return agg;
    }
    [TestMethod]
    public void AggregateFirstThree() {
        var context = new TestDBEntities();
        var startDate = new DateTime(2012, 1, 1);
        var endDate = new DateTime(2012, 1, 3);
        var aggregate = new ActivityLog();
        context.ActivityLogs.Where(entry => entry.Timestamp >= startDate && entry.Timestamp <= endDate).Aggregate(aggregate, Aggregate);
        Assert.AreEqual(66, aggregate.TranCount);
        Assert.AreEqual(36, aggregate.ReqCount);
    }
    [TestMethod]
    public void AggregateLastThree() {
        var context = new TestDBEntities();
        var startDate = new DateTime(2012, 1, 4);
        var endDate = new DateTime(2012, 1, 6);
        var aggregate = new ActivityLog();
        context.ActivityLogs.Where(entry => entry.Timestamp >= startDate && entry.Timestamp <= endDate).Aggregate(aggregate, Aggregate);
        Assert.AreEqual(75, aggregate.TranCount);
        Assert.AreEqual(45, aggregate.ReqCount);
    }
