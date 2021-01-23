       private static void WalkDirectory(DirectoryInfo directory)
       {
           if (directory.Name.ToLower() != "data")
           {
             // Scan all files in the current path
             foreach (FileInfo file in directory.GetFiles())
             {
                 file.Attributes &= ~FileAttributes.ReadOnly;
    
                 var name = file.Name;
                 name = name.ToLower();
                 if (name != "test.txt")
                 {
                   file.Delete();
                 }
             }
             DirectoryInfo[] subDirectories = directory.GetDirectories();
             foreach (DirectoryInfo subDirectory in subDirectories)
             {
                WalkDirectory(subDirectory);
                subDirectory.Attributes &= ~FileAttributes.ReadOnly;
    
                var name = subDirectory.Name;
                name = name.ToLower();
                if (name != "data")
                {
                   subDirectory.Delete();
                }
             }
          }
       }
