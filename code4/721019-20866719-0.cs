    string cs=System.Configuration.ConfigurationManager.ConnectionString["DBCS"].ConnectionString;
    using(OracleConnection con=new OracleConnection(cs))
    {
    sql="select empname from Emp where empno='"+empno+"'";
    OracleCommand cmd  = new System.Data.OracleClient.OracleCommand(sql,con);
    con.Open();
    OracleDataReader rdr = cmd.ExecuteReader();
    if(rdr.Read())
    {
    EmpName.Text=Convert.ToString(rd["empname"]);
    }
    }
