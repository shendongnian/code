    string sql1 = "update Table1 set name = 'joe' where id = 10;",
           sql2 = "update Table2 set country = 'usa' where region = 'americas';",
           sql3 = "update Table3 set weather = 'sunny' where state = 'CA';",
           sql4 = "update Table4 set engine = 'v8' where maker = 'benz';";
    string sql = string.Format("{0}{1}{2}{3}",sql1,sql2,sql3,sql4);
        
    using (OracleConnection conn = new OracleConnection())
    using (OracleCommand cmdUpdate = new OracleCommand(conn, sql))
    {
        conn.Open();
        recs = cmdUpdate.ExecuteNonQuery();
    }
