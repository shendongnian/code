    Task.Factory.StartNew(() =>
    {
        try
        {
            LogMessageToSIFDB(inClientID, tmpByte, Modified, SIF_MessageID, SIF_TimeStamp));
        }
        catch (Exception ex)
        {
            // perform your logging here
        }
    });
