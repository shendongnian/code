    static void ReceiveSocketMsgs()
    {
        TcpListener listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Any, MainForm.GOHRFTrackerMainForm.socketPortNum);
            ...
        }
        catch (Exception ex)
        {
            //some exception (if you close the app, it will be "threadabort")
        }
        finally
        {
            if (listener != null)
                listener.Stop();
        }
    }
