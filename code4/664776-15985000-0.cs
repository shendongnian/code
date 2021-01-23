    public static Dictionary<string, string> ParseQueryString( string uri ) {
    
    	string substring = uri.Substring( ( ( uri.LastIndexOf('?') == -1 ) ? 0 : uri.LastIndexOf('?') + 1 ) );
    
    	string[] pairs = substring.Split( '&' );
    
    	Dictionary<string,string> output = new Dictionary<string,string>();
    
    	foreach( string piece in pairs ){
    		string[] pair = piece.Split( '=' );
    		output.Add( pair[0], pair[1] );
    	}
    
    	return output;
    
    }
