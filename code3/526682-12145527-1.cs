    [Test]
    public void MyTest()
    {
       var mockEntity = MockRepository.GenerateMock<IUserInputEntity>();
       
       var testedClass = new MyClass(mockEntity);
    }
