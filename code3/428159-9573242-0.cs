    while (true)
    {
    
    
               foreach (Process clsProcess in Process.GetProcesses())
               {
                        if (clsProcess.ProcessName.Contains("AdobeARM"))
                        {
                              isOpened = true;
                        }
               }  
               //Once the pop up from Method 1 comes i call other methods                                  
               if (isOpened)
               {
                 Method2();
                 Method3();
                 Method4();
                 break;
               }
               else
                 break; //BREAK HERE, CAUSE NO PROCESSES of ADOBE...
    }
