    const string dbName = "evolution.sqlite";
    var dataDirectory = Path.Combine(ApplicationContext.FilesDir.AbsolutePath,
                                     "databases");
    var dataFile = Path.Combine(dataDirectory, dbName);
    if (!Directory.Exists(dataDirectory))
    {
        Directory.CreateDirectory(dataDirectory);
    }
    if (!File.Exists(dataFile))
    {
        using (var input = ApplicationContext.Assets.Open(dbName))
        using (var output = File.Create(dataFile))
        {
            var buffer = new byte[1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
