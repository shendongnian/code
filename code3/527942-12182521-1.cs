    IEnumerable<Record> records = ....
    var groups = records.GroupBy( f => f.Update );
    
    foreach( IEnumerable<Record> r in groups ){
      Write( String.Join( "/", r.Select( rec => rec.Name ).ToArray() ), r.First().Update ) );
    }
