          using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlCon"].ConnectionString))
          {
               con.open();
               MySqlDataAdapter DataDTTables = new MySqlDataAdapter(MySQLCommandFunc)
               DataDTTables.SelectCommand.CommandTimeout = 240000;
               MySQLCommandFunc.Connection = con;
               DataDTTables.Fill(DTTableTable);
               con.close();
         }
?
