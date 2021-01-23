    [TestMethod]
    public void MethodAReturnsTrueGivenSomeDataAndCondition()
    {
    IDBRepository mockRepo = new Mock<IDBRepository>(); //Create a mock of your repository call
    ClassToTest subjectToTest = new ClassToTest(mockRepo.Object); //Inject the dependency
    
    mockRepo.SetUp(r=>r.GetResult()).Returns(someSampleTestData); //You're setting up the object that might return you true to return when mock repo will be called, by default it returns the default or null usually
    
    var result = subjectToTest.MethodA();
    mockRepo.Verify(r=>r.GetResult(), Times.Once); //Make sure your repo method was called
    Assert.IsTrue(result); 
    
    }
