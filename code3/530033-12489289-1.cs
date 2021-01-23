    public static bool isRunning;
    delegate void mThread(ref book isRunning);
    delegate void AccptTcpClnt(ref TcpClient client, TcpListener listener);
    public static main()
    {
       isRunning = true;
       mThread t = new mThread(StartListening);
       Thread masterThread = new Thread(() => t(this, ref isRunning));
       masterThread.IsBackground = true; //better to run it as a background thread
       masterThread.Start();
    }
    public static void AccptClnt(ref TcpClient client, TcpListener listener)
    {
      if(client == null)
        client = listener.AcceptTcpClient(); 
    }
    public static void StartListening(ref bool isRunning)
    {
      TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, portNum));
        
      try
      {
         listener.Start();
         TcpClient handler = null;
         while (isRunning)
         {
            AccptTcpClnt t = new AccptTcpClnt(AccptClnt);
            Thread tt = new Thread(() => t(ref handler, listener));
            tt.IsBackground = true;
            // the AcceptTcpClient() is a blocking method, so we are invoking it
            // in a separate dedicated thread 
            tt.Start(); 
            while (isRunning && tt.IsAlive && handler == null) 
            Thread.Sleep(500); //change the time as you prefer
       
            if (handler != null)
            {
               //handle the accepted connection here
            }        
            // as was suggested in comments, aborting the thread this way
            // is not a good practice. so we can omit the else if block
            // else if (!isRunning && tt.IsAlive)
            // {
            //   tt.Abort();
            //}                   
         }
         // when isRunning is set to false, the code exits the while(isRunning)
         // and listner.Stop() is called which throws SocketException 
         listener.Stop();			
      }
      // catching the SocketException as was suggested by the most
      // voted answer
      catch (SocketException e)
      {
         
      }
        
    }
