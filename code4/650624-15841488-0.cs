    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    SqlDatabase db = new SqlDatabase(stringConnection);
    using (DbConnection con = db.CreateConnection())
    {
        db.ExecuteNonQuery("storedprocedure", someParams);
    }
    
