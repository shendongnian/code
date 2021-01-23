    MyWebApi
        .Routes()
        .ShouldMap(“api/WebApiController/SomeAction/5”)
        .WithJsonContent(@”{“”SomeInt””: 1, “”SomeString””: “”Test””}”)
        .And()
        .WithHttpMethod(HttpMethod.Post)
        .To(c => c.SomeAction(5, new RequestModel
        {
            SomeInt = 1,
            SomeString = “Test”
        }));
