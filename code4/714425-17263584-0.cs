        private static string GetRealPath(string path)
    {
    
       string realPath = path;
       StringBuilder pathInformation = new StringBuilder(250);
       string driveLetter = Path.GetPathRoot(realPath).Replace("\\", "");
       QueryDosDevice(driveLetter, pathInformation, 250);
       
       // If drive is substed, the result will be in the format of "\??\C:\RealPath\".
      
          // Strip the \??\ prefix.
          string realRoot = pathInformation.ToString().Remove(0, 4);
          
          //Combine the paths.
          realPath = Path.Combine(realRoot, realPath.Replace(Path.GetPathRoot(realPath), ""));
       
    
    return realPath;
    }
    
    
    [DllImport("kernel32.dll")]
    static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
    
     
