    if (result != null)
    {
        oSyncContext.Post(new System.Threading.SendOrPostCallback(
                delegate(object state)
                {
                    IBackgroundChangeClient client = (state as object[])[0] as IBackgroundChangeClient
                    //i dont konw the type of this
                    var innerResult= (state as object[])[1];
                    client.Process(innerResult);
                }), new object[] { oBackgroundChangeClient, result[4]});
    }
