    public bool TryParseUnit ( string sValue, out double fValue, out string sUnit )
    {
        fValue = 0;
        sUnit = null;
        if ( !String.IsNullOrEmpty ( sValue ) )
        {
            sUnit = GetUnit ( sValue );
            if ( sUnit != null )
            {
                return ( Double.TryParse ( sValue.Substring ( sValue.Length - sUnit.Length ),
                    out fValue );
            }
        }
        return ( false );
    }
    private string GetUnit ( string sValue )
    {
        string sValue = sValue.SubString ( sValue.Length - 1 );
        switch ( sValue.ToLower () )
        {
            case "l":
                return ( "L" );
        }
        return ( null );
    }
