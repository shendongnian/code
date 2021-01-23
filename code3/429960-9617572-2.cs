    // untested
    //Task<bool> asyncTestConn = Task.Factory.Create<bool> (
    Task<bool> asyncTestConn = new Task<bool> (
        () => TestConnection(conn, bShowErrMsg));
    asyncTestConn.ContinueWith(MyFinishCode);
    asyncTestConn.Start()
