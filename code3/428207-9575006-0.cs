    public static bool ValidName ( string name )
    {
        string strTest = name;
        if ( String.IsNullOrEmpty ( name ) )
        {
            Console.Write ( "\nInvalid Name!" );
            return false;
        }
        return true;
    }
