    FbCommand command = new FbCommand( string.Format( sql, objs ), connection );
    FbDataReader reader = command.ExecuteReader( );
    while ( reader.Read( ) )
    {
        for ( int i=0; i<reader.FieldCount; i++ )
        {
             objects[i].Add( reader.GetValue( i ) );
        }
    }
    
                
