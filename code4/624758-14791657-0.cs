    [Test]
    public void NewPlayer_Should_Return201AndLocation ()
    {
        var client = new JsonServiceClient("http://localhost:1337/");
        client.LocalHttpWebResponseFilter = httpRes => {
            //Test response headers...
        };
        PlayerResponse response = client.Post(new Player { ... });
    }
