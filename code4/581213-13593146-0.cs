    m_unitsWaitingForReadResponse= new ConcurrentDictionary<string, DateTime>();
    DateTime outVal = default(DateTime);
    if (!(m_unitsWaitingForReadResponse.TryGetValue("teststring", out outVal)))
    {
        //Do Stuff
    }
    else
    {
        //Do Stuff 2
    }
