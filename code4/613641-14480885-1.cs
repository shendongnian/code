    var fileContents = System.IO.File.ReadAllText(@"C:\Sample.txt");
    
    fileContents = fileContents.Replace("Hi","BYE"); 
    
    System.IO.File.WriteAllText(@"C:\Sample.txt", fileContents);
