    private static bool ExtractDriver(string fileName) {
      string resourceName = "OpenHardwareMonitor.Hardware." +
        (OperatingSystem.Is64BitOperatingSystem() ? "WinRing0x64.sys" : 
        "WinRing0.sys");
      string[] names =
        Assembly.GetExecutingAssembly().GetManifestResourceNames();
      byte[] buffer = null;
      for (int i = 0; i < names.Length; i++) {
        if (names[i].Replace('\\', '.') == resourceName) {
          using (Stream stream = Assembly.GetExecutingAssembly().
            GetManifestResourceStream(names[i])) 
          {
              buffer = new byte[stream.Length];
              stream.Read(buffer, 0, buffer.Length);
          }
        }
      }
      if (buffer == null)
        return false;
      try {
        using (FileStream target = new FileStream(fileName, FileMode.Create)) {
          target.Write(buffer, 0, buffer.Length);
          target.Flush();
        }
      } catch (IOException) { 
        // for example there is not enough space on the disk
        return false; 
      }
      // make sure the file is actually writen to the file system
      for (int i = 0; i < 20; i++) {
        try {
          if (File.Exists(fileName) &&
            new FileInfo(fileName).Length == buffer.Length) 
          {
            return true;
          }
          Thread.Sleep(100);
        } catch (IOException) {
          Thread.Sleep(10);
        }
      }
      
      // file still has not the right size, something is wrong
      return false;
    }
