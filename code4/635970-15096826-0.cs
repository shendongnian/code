    using (OracleConnection cn = new OracleConnection())
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["ORCLConnectionString"].ConnectionString;
        OracleCommand cm = new OracleCommand()
        cm.CommandText = "SELECT FTPOSCODE FROM PPTBL WHERE DESC LIKE :parm1";
        cm.Parameters.Add(":parm1", "%ACCOUNT%");
        cn.Open();
        SqlDataSource1.SelectCommand = cm.ToString();  // "ORA-00900: invalid SQL statement"
    }
