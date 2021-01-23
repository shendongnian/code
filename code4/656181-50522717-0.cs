    public async Task<IHttpActionResult> ActionMethod(RequestModel requestModel)
    {
       throw UserDefineException();
    }
    [Test]
    public void Test_Contrller_Method()
    {
       Assert.ThrowsAsync<UserDefineException>(() => _controller.ActionMethod(new RequestModel()));
    }    
