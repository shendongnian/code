    while (i < 5000)
    {
        Url = "http://tis-toolbox.appspot.com/api/user/id/" + i + ".xml";
        i++;
        if (i == 4999)
        {
            i = 0;
            break;
        }
        xd = new Downloader(Url, Name);
        timer = new System.Timers.Timer();
        timer.Enabled = true;
        timer.Interval = 1000;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    }
