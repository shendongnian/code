    static void Main( string[] args ) {
    
    	string fullName = "Outer<blah<int,string>,int,blah<int,int>>";			
    
    	Regex regex = new Regex( @"([a-zA-Z\._]+)\<(.+)\>$" );
    	Match m = regex.Match( fullName );
    	string frontName = m.Groups[1].Value;
    	string inner = m.Groups[2].Value;
    
    	var genArgs = ParseInnerGenericArgs( inner );
    
    	foreach( string s in genArgs ) {
    		Console.WriteLine(s);
    	}
    	Console.ReadKey();
    }
    
    private static IEnumerable<string> ParseInnerGenericArgs( string inner ) {
    	List<string> pieces = new List<string>();
    	int angleCount = 0;
    	StringBuilder sb = new StringBuilder();
    	for( int i = 0; i < inner.Length; i++ ) {
    		string currChar = inner[i].ToString();
    		if( currChar == ">" ) {
    			angleCount--;
    		}
    		if( currChar == "<" ) {
    			angleCount++;
    		}
    		if( currChar == ","  &&  angleCount > 0 ) {
    
    			sb.Append( "~" );
    			
    		} else {
    			sb.Append( currChar );
    		}
    
    	}
    	foreach( string item in sb.ToString().Split( ',' ) ) {
    		pieces.Add(item.Replace('~',','));
    	}
    	return pieces;
    }
	
