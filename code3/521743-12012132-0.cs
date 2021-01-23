    private static Regex rxNumber = new Regex( "\d+" ) ;
    public IEnumerable<string> ParseIntegersFromString( string s )
    {
        Match m = rxNumber.Match(s) ;
        for ( m = rxNumber.Match(s) ; m.Success ) ; m = m.NextMatch() )
        {
            yield return m.Value ;
        }
    }
