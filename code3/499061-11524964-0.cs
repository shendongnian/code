    Mocker = New Rhino.Mocks.MockRepository() 
    SomeRepository = Mocker.DynamicMock(Of ISomeRepository)()
    
    MyBase.UnityContainer.RegisterInstance(Of ISomeRepository)(SomeRepository)
    
    Rhino.Mocks.Expect.Call(Of SomeResult)(SomeRepository.SomeMethod("someArg")).Return(New SomeResult())
    Mocker.ReplayAll()
    
    someService = New SomeService()
    
    'this method uses IOC.Resolve(ISomeRepository) and calls the SomeRepository.SomeMethod
    someResult = someService.someMethod()
    
    Assert.IsNotNull(someResult)
