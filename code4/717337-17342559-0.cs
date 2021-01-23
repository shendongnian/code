    public void WaitUntil(Func<bool> func)
    {
        DateTime start = DateTime.Now;//(Important Note: This is ugly)
        while(DateTime.Now - start < TimeSpan.FromSeconds(12)) //?!
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
