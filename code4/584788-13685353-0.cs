     Task.Factory.StartNew(() => 
      { 
        var process = Process.Start("process.exe");
        process.WaitForExit();
      }).ContinueWith(
          //THE CODE THAT WILL RUN AFTER PROCESS EXITED.  
     
      ); 
