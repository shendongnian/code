    static int GetLastInteger( string name ) {
    
    	int value;
    	if( int.TryParse( name, out value ) ) {
    		return value;
    	}
    	System.Text.RegularExpressions.Regex r = 
    		new System.Text.RegularExpressions.Regex( @"[^0-9](\d+\b)" );
    
    	System.Text.RegularExpressions.Match m = 
    		r.Match( name );
    
    	string strValue = m.Groups[1].Value;
    	value = ( int.Parse( strValue ) );
    	return value;
    }
