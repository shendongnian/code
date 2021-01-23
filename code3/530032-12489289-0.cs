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
            tt.Start(); //the AcceptTcpClient() is a blocking method, so we are invoking it    in a seperate thread so that we can break the while loop wher isRunning becomes false
            while (isRunning && tt.IsAlive && handler == null) 
            Thread.Sleep(500); //change the time as you prefer
       
            if (handler != null)
            {
               //handle the accepted connection here
            }        
            else if (!isRunning && tt.IsAlive)
            {
               tt.Abort();
            }                   
       }
       listener.Stop();			
    }
    catch (Exception e)
    {
       Console.WriteLine(e.ToString());
    }
        
    }
