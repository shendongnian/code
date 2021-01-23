    // untested
    Task<bool> asyncTestConn = Task.Factory.Create<bool>
        (() => TestConnection(conn, bShowErrMsg));
    asyncTestConn.ContinueWith(MyFinishCode);
    asyncTestConn.Start()
