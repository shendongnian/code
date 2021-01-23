    public static List<object> CsvToJson( string body, string[] column ) {
    	if ( string.IsNullOrEmpty( body ) ) return null;
    	string[] rowSeparators = new string[] { "\r\n" };
    	string[] rows = body.Split( rowSeparators, StringSplitOptions.None );
    	body = null;
    	if ( rows == null || ( rows != null && rows.Length == 0 ) ) return null;
    	string[] cellSeparator = new string[] { "," };
    	List<object> data = new List<object>( );
    	int clen = column.Length;
    	rows.Select( row => {
    		if ( string.IsNullOrEmpty( row ) ) return row;
    		string[] cells = row.Trim( ).Split( cellSeparator, StringSplitOptions.None );
    		if ( cells == null ) return row;
    		if ( cells.Length < clen ) return row;
    		Dictionary<object, object> jrows = new Dictionary<object, object>( );
    		for ( int i = 0; i < clen; i++ ) {
    			jrows.Add( column[i], cells[i]?.Trim( ) );
    		}
    		data.Add( jrows );
    		return row;
    	} ).ToList( );
    	rowSeparators = null; rows = null;
    	cellSeparator = null;
    	return data;
    }
    
    var data = CsvToJson("csv_input_str", new string[]{ "column_map" })
    string jsonStr = new JavaScriptSerializer { MaxJsonLength = int.MaxValue }.Serialize( data );
