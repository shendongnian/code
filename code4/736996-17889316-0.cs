    else
    {
        TS_AddLogText(string.Format("Timer starts\r\n"));
        timer = new System.Timers.Timer();
        timer.AutoReset = false;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(DoStuff);
        timer.Start();
    }
