    private static DataTable GetData1( string query )
    {
      DataTable dt = new DataTable();
      string constr = ConfigurationManager.ConnectionStrings["bwic testConnectionString"].ConnectionString;
      using ( SqlConnection con = new SqlConnection( constr ) )
      using ( SqlCommand cmd = con.CreateCommand() )
      using ( SqlDataAdapter sda = new SqlDataAdapter(cmd) )
      {
        try
        {
          cmd.CommandText = query;
          cmd.CommandType = CommandType.Text;
          cmd.Connection = con;
          con.Open();
          sda.Fill( dt );
        }
        catch ( SqlException e )
        {
          // log your exception details here
          // make sure you get the type, message, stack trace as well as
          // any internal/nested exceptions.
          Console.WriteLine("Exception executing query:") ;
          Console.WriteLine(query);
          Console.WriteLine( e.ToString() );
          throw;
        }
        finally
        {
          con.Close();
        }
      }
      return dt;
    }
