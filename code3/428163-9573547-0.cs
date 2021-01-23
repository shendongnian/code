    //When Method1 is called, it will load the data and bring a pop up
    //as adobe save dialog box (as a save dialog exe in the task bar)
    Method1(); 
    //define a "timeout" time one minute from now. (or whatever)
    var timeout = DateTime.Now.AddSeconds(60);
    //loop only while the current time has not exceeded the timeout
    while (DateTime.Now < timeout)
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
            Thread.Yield(); //gives other threads CPU time; Thread.Sleep() works too.
    }
    //If we exit the loop without isOpened being set, we should probably tell someone.
    if(!isOpened) throw new Exception("The operation timed out waiting for AdobeARM.");
