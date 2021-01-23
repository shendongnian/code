    //When Method1 is called, it will load the data and bring a pop up
    //as adobe save dialog box (as a save dialog exe in the task bar)
    Method1();
    foreach (Process clsProcess in Process.GetProcesses())
    {
        if (clsProcess.ProcessName.Contains("AdobeARM"))
        {
            isOpened = true;
            break;
        }
    }
    //Once the pop up from Method 1 comes i call other methods     
    if (isOpened)
    {
        Method2();
        Method3();
        Method4();
    }
