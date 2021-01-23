    public async static Task<bool> IsConnectedAsync()
    {
        try
        {
           return await Task.Run(() =>
           {
             using (WSAppService.AppService svc = new NCSoftware.Common.WSAppService.AppService(GetServiceUrl(WebService.app)){Timeout = 5000})
             {
                  return svc.PingB();
             }
           }
         }
         catch (Exception ex)
         {
             Logger.LogException(ex.Message, ex, "IsConnectedAsync");
             return false;
         }    
    }
