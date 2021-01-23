    var transaction = sqlConn.BeginTransaction();
    SqlBulkCopy bulkCopy = new SqlBulkCopy(
        sqlConn,
        SqlBulkCopyOptions.TableLock, 
        transaction
    );
