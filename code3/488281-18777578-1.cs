    using Helper;
    
    public void ExceptionTest()
    {
        try
        {
            throw new Exception("my message").SetCode(999);
        }
        catch (Exception e)
        {
            string message = e.Message;
            int code = e.HResult;
        }
    }
