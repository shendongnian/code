    public static string getDescription(this SCSRequestType scs)
    {
        switch (scs)
        {
            case SCSRequestType.ChangeRequest:
                return "Change Request";
            case SCSRequestType.Documentation:
                return "Documentation";
            default:
                return null;
        }
    }
