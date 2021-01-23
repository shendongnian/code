    //add this either atusing System.Diagnostics;
    static void CompileJava(string javacPathName, string javaFilePathName, string commandLineOptions = "")
    {
        var startInfo = new ProcessStartInfo();    
        startInfo.CreateNoWindow = true;      
        startInfo.UseShellExecute = false;   
        startInfo.FileName = javacPathName;   
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;  
        startInfo.Arguments = commandLineOptions + " " + javaFilePathName;
  
        try {
            using (var javacProcess = Process.Start(startInfo))
            {
                javacProcess.WaitForExit();
            }
       } 
       catch(Exception e)
       {
           // do something e.g. throw a more appropriate exception
       }
       
    }
