    Process process = new Process();
    
    if(process.Start(psi))
    {
        process.WaitForExit();
    }
    else
    {
        //Do something here to handle your process failing to start
    }
