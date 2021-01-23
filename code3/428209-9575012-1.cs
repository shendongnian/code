    public static bool ValidEmail (string email)
    {
        Regex pattern = new Regex( @"(?<name>\S+)@(?<domain>\S+)" );
        Match match = pattern.Match(email);
        return !String.IsNullOrEmpty(email) && match.Success
    }
    public static bool ValidName (string name)
    {
        return !String.IsNullOrEmpty(name);
    }
