    public void startRun(object kwd)
    {
        doRun run = new doRun();
        run.run((string)kwd);
    }
    private void startBtn_Click(object sender, EventArgs e)
    {
        XmlDocument searches = new XmlDocument();
        searches.Load("data\\Searches.xml");
        XmlNodeList search = searches.SelectNodes("Searches/search");
        var nodeCount = search.Count;
        for(var i = 0; i < nodeCount; i++)
        {
            string kwd = System.Uri.EscapeDataString(search[i].SelectSingleNode("query").InnerText);
            
            ThreadPool.QueueUserWorkItem((WaitCallback)startRun, kwd);
            // replace line above with the following two lines if you want to use regular threads
            //  Thread newThread = new Thread((ParameterizedThreadStart)startRun);
            //  newThread.Start(kwd);
        }
    }
