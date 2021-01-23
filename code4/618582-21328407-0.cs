    [Test]
    public void TheTestMethod()
    {
        // arrange
        var ctrl = new MyController();
        ctrl.Request = Substitute.For<HttpRequestMessage>();  // using nSubstitute
        ctrl.Configuration = Substitute.For<HttpConfiguration>();
        // act
        HttpResponseMessage result = ctrl.Get();
        MyResponse typedresult;
        result.TryGetContentValue(out typedresult);     // <= this one
        // assert
    }
