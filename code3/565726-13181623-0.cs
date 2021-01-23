    [TestMethod]
    public void TestMethod1()
    {
        var stub = new StubIRepository<DateTime>();
        stub.GetAllOf1ExpressionOfFuncOfT0M0Int32Int32<int>(this.StubGetAll);
        var target = (IRepository<DateTime>)stub;
        IList<DateTime> datesByMonth = target.GetAll(date => date.Month);
        Assert.AreEqual(2005, datesByMonth[0].Year);
    }
    
    IList<DateTime> StubGetAll(Expression<Func<DateTime, int>> orderByExpr, int startIndex = -1, int numberOfItems = -1)
    {
        var allDates = new[] {
            new DateTime(2001, 12, 1),
            new DateTime(2002, 11, 1),
            new DateTime(2003, 10, 1),
            new DateTime(2004, 9, 1),
            new DateTime(2005, 8, 1)
        };
    
        Func<DateTime, int> orderByFunc = orderByExpr.Compile();
    
        return allDates.OrderBy(orderByFunc).ToList();
    }
