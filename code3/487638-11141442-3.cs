    // create a mock instance
    var sourceMock = MockRepository.GenerateMock<IFileDataSource>();
 
    // setup expectation
    sourceMock.Expect(m => m.Open("path", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
             .CallBack(
     delegate (string path, FileMode mode, FileAccess access, FileShare share)
     {
          // handle a call
           
         return true;
     }).Repeat.Any();
    // TODO: depends on how you are triggering LoadConnectionDetailsFromDisk method call
    // inject a mock
