    private static DataTable GetData1( string query , string p0 )
    {
      DataTable dt = new DataTable();
      string constr = ConfigurationManager.ConnectionStrings["bwic testConnectionString"].ConnectionString;
      using ( SqlConnection con = new SqlConnection( constr ) )
      using ( SqlCommand cmd = con.CreateCommand() )
      using ( SqlDataAdapter sda = new SqlDataAdapter(cmd) )
      {
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        SqlParameter p = new SqlParameter() ;
        p.Value = p0Value ;
        cmd.Parameters.Add( p ) ;
        con.Open();
        sda.Fill( dt );
        con.Close();
      }
      return dt;
    }
