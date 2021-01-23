    string sql = string.Format("select * from table where name='{0}';", your_name);
    FbCommand command = new FbCommand( sql ), connection );
    FbDataReader reader = command.ExecuteReader( );
    while ( reader.Read( ) )
    {
        for ( int i=0; i<reader.FieldCount; i++ )
        {
             objects[i].Add( reader.GetValue( i ) );
        }
    }
    
                
