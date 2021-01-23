    // Single root version.
    TestFiles.File1.AddRoot(); 
    // String literal...
    @"Relative\Path\File.xml".AddRoot();
    // Dictionary root version.
    TestExtensions.RegisterRoot("testRoot", @"C:\Some\Test\Directory");
    TestFiles.File1.AddRoot("testRoot"); 
