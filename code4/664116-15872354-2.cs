    [TestMethod]
    public void TestMethod1()
    {
        IEnumerable<int> numberOfCollection = new List<int> { 5, 14, 9, 8 };
        IList remindernumber = dividedNumbersto5(numberOfCollection);
        IList expectedNumberCollection = new List<Devided>
        {
            new Devided { Numbers = new List<int>() { 5 }, Reminder = 0 },
            new Devided { Numbers = new List<int>() { 8 }, Reminder = 3 },
            new Devided { Numbers = new List<int>() { 14, 9 }, Reminder = 4 }
        };
        CollectionAssert.AreEqual(expectedNumberCollection, remindernumber);
    }
