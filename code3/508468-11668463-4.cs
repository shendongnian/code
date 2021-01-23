    var mockRepository = new MockRepository();
    var mockObject = mockRepository.CreateMock<IFactory>();
    var yourClass = new YourClass(mockObject);    
    Expect.Call(mockObject.Create);
    mockRepository.ReplayAll();
    mockObject.VerifyDataTypesAsync()
    mockRepository.VerifyAll(); // throw Exception if your VerifyDataTypesAsync method doesn't call Create method of IFactory mock
