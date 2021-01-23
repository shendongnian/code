    static void Main( string[] args )
    {
      const string connectString = "Server=localhost;Database=sandbox;Trusted_Connection=True;";
      
      DataTable dt = new DataTable() ;
      using ( SqlConnection conn = new SqlConnection(connectString) )
      using ( SqlCommand cmd = conn.CreateCommand() )
      using ( SqlDataAdapter sda = new SqlDataAdapter(cmd) )
      {
        cmd.CommandText = @"select * from sys.objects" ;
        cmd.CommandType = CommandType.Text; 
        conn.Open();
        int rows = sda.Fill(dt) ;
      }
      
      Func<string,string> qt = x => "\"" + x.Replace("\"","\"\"") + "\"" ;
      
      DataRow dr = dt.Rows[0] ;
      string csv = dt.Columns
                     .Cast<DataColumn>()
                     .Select( c => qt(c.ColumnName) + "=" + qt(dr[c].ToString()) )
                     .Aggregate( (acc,s) => acc + "," + s )
                     ;
      Console.WriteLine(csv) ;
      
      return ;
    }
