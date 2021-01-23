    var host = '**Internal Server Name**';
    Boolean isWANConnected = false;
    String ConnectMessage ;
    AsyncCallback callBack = new AsyncCallBack(GetHostName);
    Dns.BeginGetHostEntry(host, callBack, host);
    
    static void GetHostName(IAsyncResult result)
    {
      string hostname = (string)result.AsyncState;
      try
      {
         IPHostEntry host = Dns.EndGetHostEntry(result)
         ConnectMessage = host as String;
      }
      catch(SocketException e)
      {
        isWANConnected = false;
        ConnectMessage = e.Message;
      }
    }
