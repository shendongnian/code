    public CaseOriginCode setCaseOriginCode(string caseOriginCodeParam)
    {
        switch(caseOriginCodeParam)
        {
            case "Web":
                return CaseOriginCode.Web;
            case "Email":
                return CaseOriginCode.Email;
            case "Telefoon":
                return CaseOriginCode.Telefoon;
            default:
                return default(CaseOriginCode);
        }
    }
