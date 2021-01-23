    [TestClass]
    class MyXmlWriterTests
    {
       [TestMethod]
       public void WriteData_WithValidFileAndContent_ExpectTrue()
       {
          var target = new MyXmlFileWriter();
          var filePath = Path.GetTempFile();
    
          target.WriteData(filePath, "<Xml/>");
    
          Assert.IsTrue(File.Exists(filePath));
       }
       // TODO: Check other cases
    }
