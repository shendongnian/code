    Process myProcess = new Process(); //Initialize a new Process of name myProcess
    ProcessStartInfo ps = new ProcessStartInfo(); //Initialize a new ProcessStartInfo of name ps
    
    try
    {
        ps.FileName = @"IExplore.exe"; //Set the target file name to IExplore.exe
        ps.Arguments = "-nomerge";
        ps.WindowStyle = ProcessWindowStyle.Normal; //Set the window state when the process is started to Normal
        myProcess.StartInfo = ps; //Associate the properties to pass to myProcess.Start() from ps
        myProcess.Start(); //Start the process
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message); //Write the exception message
    }
    Thread.Sleep(3000); //Stop responding for 3 seconds
    if (myProcess.HasExited) //Continue if the process has exited
    {
        //The process has exited
        //Console.WriteLine("The process has exited");
    }
    else //Continue if the process has not exited; evaluated if the process was not exited.
    {
        myProcess.Kill(); //Terminate the process
    }
