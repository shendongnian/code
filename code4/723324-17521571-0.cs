    Process chromeProcess = Process.GetProcessesByName("chrome").FirstOrDefault();
    if(chromeProcess != null)
    {
      string path = process.Modules[0].FileName;
    }
