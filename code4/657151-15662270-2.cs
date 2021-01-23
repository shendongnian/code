    string remotePath = @"\\SomeLocation";
    bool IsAccess = false;
    
    DirectoryInfo di = new DirectoryInfo(remotePath);
    if(di.Exists)
    {
        try
        {
            var acl = di.GetAccessControl();
            IsAccess= true;
        }
        catch(UnauthorizedAccessException ex)
        {
           if(ex.Message.Contains("read-only"))
           {
               IsAccess = true;
           }
           else
           {
               // No Access Fail, do something else.
           }
        }
    }
