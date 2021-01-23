    using ( SqlConnection conn = new SqlConnection( "some connect string" ) )
    using ( SqlCommand    cmd  = conn.CreateCommand() )
    {
      cmd.CommandText = @"select Update , Name from my_table order by Update , Name" ;
      cmd.CommandType = CommandType.Text ;
      
      using ( SqlDataReader reader = cmd.ExecuteReader() )
      {
        DateTime     prev_update = DateTime.MinValue ;
        List<string> names       = new List() ;
        while ( reader.Read() )
        {
          DateTime update = reader.GetDateTime( 0 ) ;
          String   name   = reader.GetString(   1 ) ;
          
          if ( update != prev_update )
          {
            if ( name.Length > 0 )
            {
              Console.WriteLine( "Annual {0} Update: {1}" , string.Join( "/" , names ) , prev_update ) ;
            }
            names.Clear() ;
            prev_update = update ;
          }
          
          names.Add( name ) ;
          
        }
        reader.Close() ;
      }
    }
  
