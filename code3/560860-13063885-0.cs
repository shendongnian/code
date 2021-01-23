    int a;
    String constring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString();
    public int Autonumber()
    {
        using(SqlConnection con = new SqlConnection(constring))
        {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        cmd.CommandText = "select pid from pid";
        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
         if (!reader.IsDBNull(0))
           a = reader.GetString(0);
        }
        reader.close();
        con.close();
        return a;
      }
    }
