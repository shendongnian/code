    try
    {
    }
    catch (System.AggregateException aex)
    {
    
        var baseEx = aex.GetBaseException() as WebException;
        if (baseEx != null)
        {
            var httpWebResp = baseEx.Response as HttpWebResponse;
            if (httpWebResp != null)
            {
                var code = httpWebResp.StatusCode;
                // Handle it...
            }                    
        }
    
        throw;
    }
