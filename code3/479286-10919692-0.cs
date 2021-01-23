    ...
    foreach(var directory in directories)
    {
     string[] files = System.IO.Directory.GetFiles(directory, "*.htm");
     DeleteFiles(files);
     var subDirectories = System.IO.Directory.GetDirectories(directory); 
     DeleteDirectories(directories);
    {
    ....
