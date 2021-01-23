    public __?___ Method(string login, string password, string something, string[] parameters, string extra = null) {
        var client = new RSClient.RSClient();
    
        if (extra == null)
            return client.GetPreparedReportSimple(login, password, something, parameters);
        else
            return client.GetPreparedReportSimple(login, password, something, parameters, extra);
    }
