    [Test] // Nunit
    [ExpectedException(typeof(Exception)) // NOTE: it's wise to throw specific 
    // exceptions so that you prevent false-positives! (another "exception" 
    // might make the test pass while it's a completely different scenario)
    public void Error_Is_Thrown_If_HVM_FormCollection_Data_Is_Incorrect()
    {
        var formCollection = new FormCollection();
        formCollection.Add("__RequestVerificationToken", "__RequestVerificationToken");
        formCollection.Add("invalid - invalid", "invalid- invalid");
        var payType = new PaymentType();
        payType = PaymentType.deposit;
        var progCode = "hvm";
        var httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
        var httpContext = MockRepository.GenerateMock<HttpContextBase>();
        
        // define behaviour
        httpRequest.Expect(r => r.Url).Return(new Uri("http://localhost:8080/hvm/full/self/")).Repeat.Any();
        httpContext.Expect(c => c.Request).Return(httpRequest).Repeat.Any();
        // instantiate SuT (system under test)
        controller.ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);
        // Test the stuff, and if nothing is thrown then the test fails
        var result = controller.Index(formCollection, payType, progCode);
    }
