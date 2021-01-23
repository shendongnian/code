    public IEnumerable<IResult> Login(string username, string password)
    {
        _credential.Username = username;
        _credential.Password = password;
    
        var result = new Result();
        var request = new GetUserSettings(username);
    
        yield return new ProcessQuery(request, result, "Logging In...");
    
        if (result.HasErrors)
        {
            yield return new ShowMessageBox("The username or password provided is incorrect.", "Access Denied");
            yield break;
        }
    
        var response = result.GetResponse(request);
    
        if(response.Permissions == null || response.Permissions.Count < 1)
        {
            yield return new ShowMessageBox("You do not have permission to access the dashboard.", "Access Denied");
            yield break;
        }
    
        _context.Permissions = response.Permissions;
    
        yield return new OpenWith<IShell, IDashboard>();
    }
