    using (OracleConnection cn = new OracleConnection())
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["ORCLConnectionString"].ConnectionString;
        OracleCommand cm = new OracleCommand(cn);
        cm.CommandText = "SELECT FTPOSCODE FROM PPTBL WHERE DESC LIKE :parm1";
        cm.Parameters.Add(":parm1", "%ACCOUNT%");
        cn.Open();
        var reader = cm.ExecureReader();
    }
