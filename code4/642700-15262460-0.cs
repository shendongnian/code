    private void Methodname(string SQLConn, object[] param)
    {
        ...
        cmd.Parameters.Add(new SqlParameter("@mBatchName", param[0]));
        cmd.Parameters.Add(new SqlParameter("@mTATCash", param[1]));
        cmd.Parameters.Add(new SqlParameter("@mTATradingOrdinary", param[2]));
        cmd.Parameters.Add(new SqlParameter("@mTATradingType", param[3])); 
