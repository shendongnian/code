    string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
    foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
    {
      var assemblyFromCurrentDomain = Assembly.Load(Assembly.LoadFile(dll).FullName);
    
      Debug.Print("Add Assembly : {0}, {1}", assemblyFromCurrentDomain.FullName, assemblyFromCurrentDomain.Location);
    }
