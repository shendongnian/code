    public string Call()
    {
        string ref1 = Request.ServerVariables["HTTP_REFERER"];
        Response.Write(ref1);
    }
