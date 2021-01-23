    void Main()
    {
       DirectoryInfo directory = new DirectoryInfo("D:\\test");
       DirectoryInfo[] folders = directory.GetDirectories(@"*.*",SearchOption.AllDirectories);
                
       var query2 = from folder in folders
                    where folder.GetFileSystemInfos().Length > 0
                    select folder.FullName.ToString();
                
      folders.Select(f => f.GetFileSystemInfos()).Dump();
      query2.Dump();
     
      foreach (string str in query2)
      {
        Console.WriteLine(str);
      }
    }
