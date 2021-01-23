    string result = new PasswordRegexGenerator ( )
    		.UpperCase ( 3, -1 )    // ... {3,}
    		.Number ( 2, 4 )        // ... {2,4}
    		.SpecialCharacter ( 2 ) // ... {2}
    		.Total ( 8,-1 )
    		.Compose ( );
    /// <summary>
    /// Generator for regular expression, validating password requirements.
    /// </summary>
    public class PasswordRegexGenerator
    {
    	private string _elementTemplate = "(?=(?:.*?({type})){({count})})";
    	
    	private Dictionary<string, string> _elements = new Dictionary<string, string> {
    		{ "uppercase", "[A-Z]" },
    		{ "lowercase", "[a-z]" },
    		{ "number", @"\d" },
    		{ "special", @"\W" },
    		{ "alphanumeric", @"\w" }
    	};
    
    	private StringBuilder _sb = new StringBuilder ( );
    
    	private string Construct ( string what, int min, int max )
    	{
    		StringBuilder sb = new StringBuilder ( _elementTemplate );
    		string count = min.ToString ( );
    
    		if ( max == -1 )
    		{
    			count += ",";
    		}
    		else if ( max > 0 )
    		{
    			count += "," + max.ToString();
    		}
    
    		return sb
    			.Replace ( "({type})", what )
    			.Replace ( "({count})", count )
    			.ToString ( );
    	}
    
    	/// <summary>
    	/// Change the template for the generation of the regex parts
    	/// </summary>
    	/// <param name="newTemplate">the new template</param>
    	/// <returns></returns>
    	public PasswordRegexGenerator ChangeRegexTemplate ( string newTemplate )
    	{
    		_elementTemplate = newTemplate;
    		return this;
           }
    
    	/// <summary>
    	/// Change or update the regex for a certain type ( number, uppercase ... )
    	/// </summary>
    	/// <param name="name">type of the regex</param>
    	/// <param name="regex">new value for the regex</param>
    	/// <returns></returns>
    	public PasswordRegexGenerator ChangeRegexElements ( string name, string regex )
    	{
    		if ( _elements.ContainsKey ( name ) )
    		{
    			_elements[ name ] = regex;
    		}
    		else
    		{
    			_elements.Add ( name, regex );
    		}
    		return this;
    	}
    
    	#region construction methods 
    
    	/// <summary>
    	/// Adding number requirement
    	/// </summary>
    	/// <param name="min"></param>
    	/// <param name="max"></param>
    	/// <returns></returns>
    	public PasswordRegexGenerator Number ( int min = 1, int max = 0 )
    	{
    		_sb.Append ( Construct ( _elements[ "number" ], min, max ) );
    		return this;
    	}
    
    	public PasswordRegexGenerator UpperCase ( int min = 1, int max = 0 )
    	{
    		_sb.Append ( Construct ( _elements[ "uppercase" ], min, max ) );
    		return this;
    	}
    
    	public PasswordRegexGenerator LowerCase ( int min = 1, int max = 0 )
    	{
    		_sb.Append ( Construct ( _elements[ "lowercase" ], min, max ) );
    		return this;
    	}
    
    	public PasswordRegexGenerator SpecialCharacter ( int min = 1, int max = 0 )
    	{
    		_sb.Append ( Construct ( _elements[ "special" ], min, max ) );
    		return this;
    	}
    
    	public PasswordRegexGenerator Total ( int min, int max = 0 )
    	{
    		string count = min.ToString ( ) + ( ( max == 0 ) ? "" : "," + max.ToString ( ) );
    		_sb.Append ( ".{" + count + "}" );
    		return this;
    	}
    
    	#endregion
    
    	public string Compose ()
    	{
    		return "(" + _sb.ToString ( ) + ")";
    	}
    }
