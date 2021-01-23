    [Test]
    public void GetBarIsNotNullTest()
    {
        var bar = IoC.Current.Resolve<Bar>();
        var actual = bar.GetDon();
        Assert.IsNotNull(actual);   
    }
