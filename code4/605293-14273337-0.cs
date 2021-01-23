    public string MemberLogOut()
    {
        string ret = string.Empty;
        try
        {
            if (HttpContext.Current.Session!=null)
            {HttpContext.Current.Session.Clear();}
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        return "1";
    }
