    private const int MaxRetries = 10;
    private void OnSendTask(object sender, SendTaskEventArgs args)
    {
        bool retry = false;
        try
        {
            tcp_connection_lock_.WaitOne();
            using (TcpClient recipient = new TcpClient())
            {
                // error here!
                recipient.Connect(args.IPAddress, args.Port);
                using (NetworkStream stream = recipient.GetStream())
                {
                    // read/write data
                }
            }
        }
        catch (SocketException ex)
        {
            if(args.RetryCount < MaxRetries)
            {
                retry = true;
                args.RetryCount++;
            }
            else
            {
                // write exceptions to the logfile
            }
        }
        finally
        {
            tcp_connection_lock_.Release();
        }
    
        if(retry)
        {
            Thread.Sleep(1);
            OnSendTask(sender, args);
        }
    }
