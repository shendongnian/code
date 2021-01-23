    public static DataSet Confirmation()
    { 
    SqlCommand cmdSQL = new SqlCommand("uspConfirmation", Connection);
    cmdSQL.CommandType = CommandType.StoredProcedure;
    
    cmdSQL.Parameters.Add(new SqlParameter("@RecordID", SqlDbType.VarChar, 36));
    cmdSQL.Parameters["@RecordID"].Direction = ParameterDirection.Input;
    cmdSQL.Parameters["@RecordID"].Value = RecordIDSession;
    
    cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.VarChar, 30));
    cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
    cmdSQL.Parameters["@LName"].Value = LNameSession;
    
    cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.VarChar, 30));
    cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
    cmdSQL.Parameters["@FName"].Value = FNameSession;
    
    cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.Char, 1));
    cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
    cmdSQL.Parameters["@MInit"].Value = MNameSession;
    
    cmdSQL.Parameters.Add(new SqlParameter("@RecordCount", SqlDbType.Int));
    cmdSQL.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
    
    
    
    SqlDataAdapter da = new SqlDataAdapter(cmdSQL);
    DataSet ds = new DataSet();
    da.Fill(ds);
    
    try
    {
        Connection.Open();
        cmdSQL.ExecuteNonQuery();
    
    }
    catch (Exception ex)
    {
        dbMsg = ex.Message;
    }
    finally
    {
        Connection.Close();
        cmdSQL.Dispose();
        cmdSQL.Parameters.Clear();
    }
    //VARIABLE TO HOLD ROW COUNT VIA OUTPUT VIARABLE
    Int32 intRecCount = Convert.ToInt32(cmdSQL.Parameters["@RecordCount"].Value);
    
    return ds;
    }
