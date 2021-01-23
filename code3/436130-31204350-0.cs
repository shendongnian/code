    //ARRANGE
            var logger = new Mock<ILogger>();
            var handler= new ServiceLoggingHandler(logger.Object);
            var request = ControllerContext.CreateHttpRequest(Guid.NewGuid(), "http://test",HttpMethod.Get);
            handler.InnerHandler = new Mock<HttpMessageHandler>(MockBehavior.Loose).Object;
            request.Content = new ObjectContent<CompanyRequest>(Company.CreateCompanyDTO(), new JsonMediaTypeFormatter());
            var invoker = new HttpMessageInvoker(handler);
            //ACT
            var result = invoker.SendAsync(request, new System.Threading.CancellationToken()).Result;
    //ASSERT
    <Your assertion>
