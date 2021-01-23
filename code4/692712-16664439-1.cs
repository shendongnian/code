    [WebMethod(MessageName="Test")]
    public string GenerateMessage(string firstName)
    {
       return string.Concat("Hi ", firstName);
    }
    
    [WebMethod(MessageName="AnotherTest")]
    public string GenerateMessage(string firstName, string lastName)
    {
       return string.Format("Hi {0} {1}", firstName, lastName);
    }
