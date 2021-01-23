     using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlCon"].ConnectionString))
     {
          con.open();
          MySQLCommandFunc.Connection = con;
          DataDTTables.Fill(DTTableTable);
          con.close();             
     }
?
