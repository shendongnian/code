    public string File_location()
    {
        get
        {
            string location = Request.QueryString;
            return = location.Substring(location.IndexOf('=') + 1);
        }
    }
