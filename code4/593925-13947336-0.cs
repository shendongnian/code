    using(var connection = ...)
    {
        connection.Open();
        using (var tran = connection.BeginTransaction())
        {
            try
            {
                FBSave(connection, tran);
                FBSaveDetails(connection, tran);
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
