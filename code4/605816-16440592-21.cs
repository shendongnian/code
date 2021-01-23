    [TestClass]
    class FileRepositoryTests
    {
       private FileRepository repository = null;
      
       [TestInitialize()]
       public void Initialize()
       {
        this.repository = new FileRepository( new FakeFileWriter() );
       }
    
       [TestMethod]
       public void WriteData_WhenCalled_ExpectSuccess()
       {
           // Arrange
           var target = repository;
      
           // Act
           var actual = repository.Save(null,null);
    
           // Assert
           Assert.IsTrue(actual);
       }
    }
