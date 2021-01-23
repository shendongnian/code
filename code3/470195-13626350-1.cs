    HttpResponseBase response = MockRepository.GenerateMock<HttpResponseBase>();
    			
    // stub the getter
    response.Stub(r => r.StatusCode).Return((int)HttpStatusCode.OK);
    			
    // Stub the setter
    response.Stub(r => r.StatusCode = Arg<int>.Is.Anything).WhenCalled( o =>
      {
        Console.WriteLine("called");
      });
