    [Test]
    public void NewPlayer_Should_Return201AndLocation ()
    {
        var mockCtx = new Mock<IRequestContext>();
        mockCtx.SetupProperty(f => f.AbsoluteUri, "http://localhost:1337/player");
        PlayerService service = new PlayerService {
            MyOtherDependencies = new Mock<IMyOtherDeps>().Object,
            RequestContext = mockCtx.Object,
        };
        HttpResult response = (HttpResult)service.Post(new Player { ... });
        //Assert stuff..
    }
