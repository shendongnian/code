    /*Important Note: This is ugly, error prone 
              and causes eye itchiness to veteran programmers*/
    public void WaitUntil(Func<bool> func)
    {
        DateTime start = DateTime.Now;
        while(DateTime.Now - start < TimeSpan.FromSeconds(12))
        {
            if (func())
            {
                    return;
            }
            Thread.Sleep(100);
        }
        /* Thow exception */
    }
    //Call
    WaitUntil(() => Visible(/* Some page element*/));
