    while(true)
    {
        lock (p.ProgressPercent)
        {
            int _p = p.ProgressPercent;
        }
        if(_p==0)
        {
            Thread.sleep(1000);
        }
        else
        {
            progressBar1.Value=_p;
        }
    }
