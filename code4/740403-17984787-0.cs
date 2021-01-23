    ManualResetEvent wait = new ManualResetEvent(false);
    wc.DownloadStringCompleted  += (s,e) => {                                         
                                   if(e.Error!=null)
                                      rawWebReturn = e.Error.Message;
                                   else
                                      rawWebReturn = e.Result;
                                   Wait.Set();
                                };
    wait.WaitOne();
    return parseWebReturn(rawWebReturn,ret); 
