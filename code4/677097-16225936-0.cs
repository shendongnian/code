    [Test]
    public void testsomethign()
    {
        var mockedRequestContext = MockRepository.GenerateMock<IRequestContext>();
        var mockedHttpRequest = MockRepository.GenerateMock<IHttpRequest>();
        var mockedOriginalRequest = MockRepository.GenerateMock<HttpRequestBase>();
        var mockedOriginalRequestContext = MockRepository.GenerateMock<RequestContext>();
    
        mockedOriginalRequest.Stub(x => x.RequestContext).Return(mockedOriginalRequestContext);
        mockedHttpRequest.Stub(x => x.OriginalRequest).Return(mockedOriginalRequest);
    
        mockedRequestContext.Stub(x => x.Get<IHttpRequest>()).Return(mockedHttpRequest);
        var service = new ServiceTests()
        {
            RequestContext = mockedRequestContext
        };
    
        service.Delete(new DeleteRequest());
    }
