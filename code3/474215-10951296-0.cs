    			SqlConnection sqlCon = new SqlConnection( ExternalDatabaseConnectionString );
    			SqlCeConnection sqlCECon = new SqlCeConnection( BackUpConnectionString );
    			using ( sqlCon )
    				{
    				using ( sqlCECon )
    
    					{
    					sqlCon.Open( );
    					sqlCECon.Open( );
    					SqlCommand get = new SqlCommand( "Select * from [TableToRead]", sqlCon );
    					SqlCeCommand save = new SqlCeCommand( "Update [BackUpTable] set InfoColumn = @info where ID = @id", sqlCECon );
    					SqlDataReader reader = get.ExecuteReader( );
    					if ( reader.HasRows )
    						{
    						reader.Read( );
    save.Parameters.AddWithValue("@id", reader.GetString(0));
        						save.Parameters.AddWithValue( "@info", reader.GetString( 1 ));
        						save.ExecuteNonQuery( );
        						}
        					}
        				}
