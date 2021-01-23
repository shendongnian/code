    WriteException(Exception ex, int index, string s)
    {
        var soapEx = ex as SoapException;
        
        if(null != soapEx)
        {
          Console.WriteLine(soapEx.Detail.InnerText);
          return;
        }
        
        Console.WriteLine(ex.Message);
    
    }
