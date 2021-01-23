    try
    {
        //Start first session request in new thread.
        Task<Session> task = Task.Factory.StartNew(() => GetSession(server1, logon, password));
        //Start second request in current thread, wait for first to complete.
        session2 = GetSession(server2, logon, password));
        session1 = task.Result; // This blocks, and will raise an exception here, on this thread
    }
    catch(Exception ex)
    {
        // Now this will get hit
        MessageBox.Show(ex.ToString());
        return;
    }
