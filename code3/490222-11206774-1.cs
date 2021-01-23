    using(SqlConnection conn = Class3.GetConnection())
    {
        foreach(var obj in conn.Query("whatever",
              commandType: CommandType.StoredProcedure))
        {
            string menuename = obj.menuename;
            // do something...
        }
    }
