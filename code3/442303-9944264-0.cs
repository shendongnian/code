    public bool TryGetResult(Func<string> resultAccessor, out string result)
    {
        try
        {
            result = resultAccessor();
            return true;
        }
        catch(WebException)
        {
            HandleWebException();
            result = null;
            return false;
        }
    }
    void fun1(DownloadStringCompletedEventArgs e)      
    {
        string result;
        if (TryGetResult(() => e.Result, out result))
        {
            // Success
        }
    }      
          
    void fun2(UploadStringCompletedEventArgs e)      
    {      
        string result;
        if (TryGetResult(() => e.Result, out result))
        {
            // Success
        }
    }  
