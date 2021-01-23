    var tran = db.BeginTransaction();
    try {
      
      SqlCommand com = new SqlCommand(...., tran);
      // or.  
      com.Transaction=tran;
      // do the work, eg execute SQL 
      // finally commit the changes
      tran.Commit();
    }
    catch
    {
      tran.Rollback();
    }
 
