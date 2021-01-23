    using(var con=new OracleConnection(connectionString))
    {
       con.open();
       var sql = "insert into users values (:id,:name,:surname,:username)";
   
       using(var cmd = new OracleCommand(sql,con)
       {
          OracleParameter[] parameters = new OracleParameter[] {
                 new OracleParameter("id",1234),
                 new OracleParameter("name","John"),
                 new OracleParameter("surname","Doe"),
                 new OracleParameter("username","johnd")
          };
          cmd.Parameters.AddRange(parameters);
          cmd.ExecuteNonQuery();
       }
    }
