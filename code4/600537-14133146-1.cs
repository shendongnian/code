       string query = @"UPDATE bartran SET aNumberCounter = ? WHERE id = ?;";
       string cnstr=@"Driver={{MySQL ODBC 5.1 Driver}};Server=localhost;dataBase=database_name;User=root;Password=;Option=3;";
       using(OdbcConnection connection=new OdbcConnection(cnstr))
       {
        using(OdbcCommand cmd=new OdbcCommand(query,connection))
        {
        cmd.Parameters.Add("?",OdbcType.Int);
        cmd.Parameters.Add("?",OdbcType.Int);
        connection.Open();
        for (int i = 0; i < dsData.Tables["data"].Rows.Count; i++)
         {
          ...
          cmd.Parameters[0].Value=aNumberCounter;
          cmd.Parameters[1].Value=id;
          cmd.ExecuteNonQuery();
          }
        connection.Close();
        }
       }
