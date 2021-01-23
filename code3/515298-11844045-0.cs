    public void ExecuteQuery(string usrName, string role, string activeation, int userId)
    {
      string sql = "UPDATE LD_USER_ROLE SET USERNAME=:usrName, ROLE=:role, ACTIVE_IND=:actvInd  WHERE USER_ROLE_ID=:id";
        OracleCommand cmd = new OracleCommand(sql, conn);
        cmd.BindByName = true;
        cmd.Parameters.Add("usrName", usrName);
        cmd.Parameters.Add("role", role);
        cmd.Parameters.Add("actvInd", activeation);
        cmd.Parameters.Add("id", userId);
        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
    }
