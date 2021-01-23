    string updateSql = "UPDATE MATERIALMOVEREQUEST SET PROCESS_FLAG = :parameter1 WHEREUNIQUEKEY = :parameter2";"
    OracleCommand cmd = new OracleCommand(updateString, conn1);
    cmd.BindByName = true;
    cmd.Parameters.Add("parameter1", Convert.ToChar(ddl1.SelectedValue);
    cmd.Parameters.Add("parameter2", uKey);
    myTrans = conn1.BeginTransaction(IsolationLevel.ReadCommitted);
    cmd.Transaction = myTrans;
    try
    {
         cmd.ExecuteNonQuery();
         myTrans.Commit();
    }
    catch
    {
         myTrans.Rollback();
    }
