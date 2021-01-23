     using System.Diagnostics;
     Process[] processlist = Process.GetProcesses();
     
     foreach(Process theprocess in processlist){
           // you'll actually need to use something like the process name or id here.
           if (theprocess == MyThirdPartyComponentsProcess)
           {
                 theprocess.StartInfo.UseShellExecute = false;
                 theprocess.StartInfo.RedirectStandardOutput = true; 
            }
      }
