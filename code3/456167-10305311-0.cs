    private DbParameter CreateDateParameter(DbCommand cmd, DateTime date) 
    {
         DbParameter param = cmd.CreateParameter();
         param.DbType = DbType.DateTime;
         param.Direction = ParameterDirection.Input;
         param.Value = date.ToString("yyyy-MM-dd hh:mm:ss");
         return param;
    } 
