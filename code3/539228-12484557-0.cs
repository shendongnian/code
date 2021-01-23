    // local times
    DateTime creationTime = File.GetCreationTime(@"c:\file.txt");
    DateTime lastWriteTime = File.GetLastWriteTime(@"c:\file.txt");
    DateTime lastAccessTime = File.GetLastAccessTime(@"c:\file.txt");
    
    // UTC times
    DateTime creationTimeUtc = File.GetCreationTimeUtc(@"c:\file.txt");
    DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(@"c:\file.txt");
    DateTime lastAccessTimeUtc = File.GetLastAccessTimeUtc(@"c:\file.txt");
    
    // write file last modification time (local / UTC)
    Console.WriteLine(lastWriteTime);     // 9/30/2007 2:16:04 PM
    Console.WriteLine(lastWriteTimeUtc);  // 9/30/2007 6:16:04 PM
