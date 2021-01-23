    Process proc = new Process(); 
    proc.EnableRaisingEvents = false; 
    proc.StartInfo.FileName = Path.Combine(exePath, @"A.exe");
    proc.StartInfo.Arguments = String.Format(@"-i = ""{0}"" -o = ""{1}""", "123", "abc");
    proc.Start()
