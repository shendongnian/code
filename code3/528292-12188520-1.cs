    public string Call()
    {
        string ref1 = Request.ServerVariables["HTTP_REFERER"];
        Request.Response.Write(ref1);
    }
