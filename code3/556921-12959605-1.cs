    var parts = new List<string>();
    
    if( criteria.Make.HasValue )
    {
       parts.Add( string.Format( "make = '{0}'", criteria.Make.Value ) );
    }
    
    if( criteria.Model.HasValue )
    {
       parts.Add( string.Format( "model = '{0}'", criteria.Model.Value ) );
    }
    
    query += string.Join( " AND ", parts );
