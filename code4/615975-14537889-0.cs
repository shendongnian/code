    {
        DbContext db;
        try
        {
            var db = GetDataSet(db, "GetAllCustomers");
             // data access code
        }
        finally
        {
            db.Dispose();
        }
    }
