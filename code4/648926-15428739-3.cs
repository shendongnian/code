    MySqlConnection myConn = new MySqlConnection(connStr);
        
        string sqlStr = "SELECT CONCAT(Name, ' ', Score) as NameAndScore " + 
                        "FROM highscore ORDER BY Score DESC";
    
      myConn .Open();
      
      SqlCommand cmd = new SqlCommand(sqlStr, SQLConnection1);
    
    
          SqlDataReader rd = cmd.ExecuteReader();
          while (rd.Read())
          {
            lstNames.Items.Add(rd[0]);
          }
          rd.Close();
          rd.Dispose();
          myConn.Close();
