    public static string Replace(string typeval)
    {
        typeval = typeval.Replace("User Service Request", "incident");
        typeval = typeval.Replace("User Service Restoration", "u_request");
    
        return typeval;
    }
