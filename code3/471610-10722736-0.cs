    [TearDown]
    public void CleanUp()
    {
        HttpContext.Current = null;
    }
    [Test]
    public void FakeHttpContext()
    {
        var context = Substitute.For<HttpContextBase>();
        var request = Substitute.For<HttpRequestBase>();
        context.Request.Returns(request);
        //Do any more arragement that you need.
        //Act
        //Assert
    }
