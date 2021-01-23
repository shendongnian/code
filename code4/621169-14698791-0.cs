    void SendFilesToServer()
    {
        string filename;
        try
        {
            while(true)
            {
                while (q.TryTake(out fileName))
                {
                    // Send to the webservice
                }
                while(q.IsEmpty)
                    Thread.Sleep(100);
            }
        }
        catch (InvalidOperationException)
        {
        }
    }
