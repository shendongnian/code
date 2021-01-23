    for (int i = 0; i < Session.Count; i++)
    {
        var crntSession = Session.Keys[i];
        Response.Write(string.Concat(crntSession, "=", Session[crntSession]) + "<br />");
    }
