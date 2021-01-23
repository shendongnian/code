    string[] files = System.IO.Directory.GetFiles(Windows_95_98_Me, "host*.*");
    
    foreach (string s in files) {
        System.IO.File.Copy(s, System.IO.Path.Combine(targetPath, System.IO.Path.GetFileName(s)), true);
    }
