    private bool IsAccessDenied(Auth auth)
    {
        return !(auth.DoesAuthMatch && auth.DoesEmailMatch);
    }
    
    if (IsAccessDenied(auth))
    {
        statusText = "Access Denied";
    }
