    var filez = Directory.GetFiles(@"c:\MLBWRT", "*.dll", SearchOption.AllDirectories)
            .Where(
                s => s.ToLower().Contains("microsoft")
                && s.ToLower().Contains("ibm")
                && s.ToLower().Contains("nhibernate"));
    string[] allFiles = filez.ToArray<string>();
    for (int i = 0; i < allFiles.Length; i++) {
        FileInfo fInfo = new FileInfo(allFiles[i]);
        Console.WriteLine(fInfo.Name);
    }
