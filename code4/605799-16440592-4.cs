    class FakeFileWriterTests
    {
       private IFileWriter writer;
    
       [TestInitialize()]
       public void Initialize()
       {
          writer = new FakeFileWriter();
       }
    
       [TestMethod]
       public void WriteData_WhenCalled_ExpectSuccess()
       {
          writer.WriteData(null,null);
          Assert.IsTrue(writer.WriteDataCalled);
       }
    }
