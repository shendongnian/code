    public String GetNumberForDataTypeofColumn(String TableName, String ColumnName)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@TableName", TableName);
        param[1] = new SqlParameter("@ColumnName", ColumnName);
        String result = SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["cn"].ConnectionString, CommandType.StoredProcedure, "proc_GetDataTypeValueByColumnName", param).ToString();
        return result;
    }
