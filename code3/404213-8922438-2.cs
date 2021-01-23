    WriteException(Exception ex, int index, string s)
    {
        dynamic soapEx = ex;
        
        Console.WriteLine(soapEx.Detail.InnerText);
        Console.WriteLine(ex.Message);
    
    }
