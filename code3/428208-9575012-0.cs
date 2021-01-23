    public static bool ValidEmail ( string email )
    {
        Regex pattern = new Regex( @"(?<name>\S+)@(?<domain>\S+)" );
        Match match = pattern.Match(email);
        if ( String.IsNullOrEmpty ( email ) || !match.Success )
            return false;
        else
            return true;
    }
    public static bool ValidName ( string name )
    {
        return String.IsNullOrEmpty(name);
    }
