    static void Main( string[] args )
    {
        string   sourceText = "#Name #Location New York #Rating" ;
        
        // option 1: split on whitespace and then toss whatever isn't wanted
        string[] hashTokens1 = sourceText.Split().Where( x => x.StartsWith("#") ).ToArray() ;
        
        // option 2: actively search for what is desired
        string[] hashTokens2 = ParseSourceData( sourceText ).ToArray() ;
        
        return ;
        
    }
    
    private static readonly Regex hashTokenPattern = new Regex( @"#\w+");
    private static IEnumerable<string> ParseSourceData( string s )
    {
        for ( Match m = hashTokenPattern.Match( s ) ; m.Success ; m = m.NextMatch() )
        {
            yield return m.Value ;
        }
    }
