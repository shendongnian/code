    LiveAuthClient authCilent = new LiveAuthClient();
    LiveLoginResult loginResult;
    loginResult = authCilent.InitializeAsync().Result;
    if (loginResult.Status == LiveConnectSessionStatus.Connected)
    {
       /* 
       Also use loginResult.Session as the Session which you will require to use live services by creating LiveConnectClient instance as follows.
       */
       // LiveConnectClient liveClient = new LiveConnectClient(loginResult.Session);
       // Write the logic you want by using liveClient instance
    }
