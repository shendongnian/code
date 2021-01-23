    public static void UninstallAssembly(string assemblyName) {
       ProcessStartInfo processStartInfo = new ProcessStartInfo("gacutil.exe", 
          string.Format("/u {0}.dll", assemblyName));
    
       processStartInfo.UseShellExecute = false;
       Process process = Process.Start(processStartInfo);
       process.WaitForExit;
    }
