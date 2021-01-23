    using System;
    using System.IO; //needed for path.getdirectoryname() and directory.getcurrentdirectory()
    
    string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
    
    AppDomain.CurrentDomain.SetData("DataDirectory", path);
