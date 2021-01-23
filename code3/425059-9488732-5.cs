    [TestMethod]
    public void Weekend_Is_Still_Far_Away_From_The_28_th_Of_February_2012()
    {
        // arrange
        Func<DateTime> providerMock = () => new DateTime(2012, 2, 28);
        var sut = new WeekendTester(providerMock);
    
        // act
        var actual = sut.IsWeekendSoon();
    
        // assert
        Assert.IsFalse(actual);
    }
