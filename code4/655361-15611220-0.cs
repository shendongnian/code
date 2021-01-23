    SqlConnection SqlConn = new SqlConnection(this.ConnectionString);
    SqlConn.Open();
    SqlCommand SqlCmd = new SqlCommand(" Your Select....", SqlConn);
    SqlCmd.CommandType = CommandType.Text;
    SqlDataReader r = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
    //----need this 
    while (r.Read())                
    itemname.Text =  string.IsNullOrEmpty(r["Itemname"].ToString()) ?  
      string.Empty : r["Itemname"].ToString();           
     r.Close();
     if (SqlConn.State != ConnectionState.Closed)
          SqlConn.Close();
