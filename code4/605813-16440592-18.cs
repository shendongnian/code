    // Put this class in the test suite, not the main project
    class FakeFileWriter : IFileWriter
    {
       internal bool WriteDataCalled { get; private set; }
    
       public bool WriteData(string file, string content)
       {
           this.WriteDataCalled = true;
           return true;
       }
    }
