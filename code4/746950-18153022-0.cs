    public async static Task<bool> IsConnectedAsync()
    {
        try
        {
             using (WSAppService.AppService svc = new NCSoftware.Common.WSAppService.AppService(GetServiceUrl(WebService.app)){Timeout = 5000})
             {
                  return await svc.PingBAsync();
             }
         }
         catch (Exception ex)
         {
             Logger.LogException(ex.Message, ex, "IsConnectedAsync");
         }    
         return false;
    }
