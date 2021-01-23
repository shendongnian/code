    while (true) // Run in a separate thread to prevent blocking if that will be a problem
    {
    Process[] proclist = Process.GetProcessByName("bf3.exe");
    if (proclist.Length > 0)
        {
            //BF3 is running, do something here
        }
    else
        {
            //BF3 isn't running any more, do something here
        }
    }
