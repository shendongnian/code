     DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "YourDirectoryRepository"));
     FileInfo[] files = dInfo.GetFiles("*.dll");
     List<Assembly> plugInAssemblyList = new List<Assembly>();
 
     if (null != files)
     {
          foreach (FileInfo file in files)
          {
               plugInAssemblyList.Add(Assembly.LoadFrom(file.FullName));
          }
     }
