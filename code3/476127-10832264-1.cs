        string path = @"C:\Kuldeep\kverma\kver\";
        string[] directoryArray = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        
        foreach (var directory in directoryArray)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(directory);
            String name = dirinfo.Name;
            String pth = dirinfo.FullName;
            Console.WriteLine(name, pth);
        }
