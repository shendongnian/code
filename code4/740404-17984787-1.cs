    public static void Login(String username, String password, Action<dbObj> callback)
    {
        // ...
        wc.DownloadStringCompleted  += (s,e) => {                                         
                                   if(e.Error!=null)
                                      rawWebReturn = e.Error.Message;
                                   else
                                      rawWebReturn = e.Result;
                                   Callback(parseWebReturn(e.Result, ret););
                                };
    }
