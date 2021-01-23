    public void ExecuteCMD(string storedProcedure, OracleParameter[] param)
    {
    OracleCommand oraCmd = new OracleCommand();
    oraCmd,CommandType = CommandType.StoredProcedure;
    oraCmd.CommandText = storedProcedure;
    oraCmd.Connection = oraConnection;
    
    if(param!=null)
    {
    oraCmd.Parameters.AddRange(param);
    }
    try
    {
    oraCmd.ExecuteNoneQuery();
    }
    catch (Exception)
    {
    MessageBox.Show("Sorry We've got Unknown Error","Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
    }
    }
