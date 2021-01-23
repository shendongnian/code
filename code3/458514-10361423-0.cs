        SqlConnection cn = new   
        SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);        
        cn.Open();
        SqlCommand cmd = new SqlCommand(procname, cn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter str = new SqlParameter("name", SqlDbType.VarChar);
        str.Direction = ParameterDirection.ReturnValue;
        foreach (SqlParameter par in param)
        {
            cmd.Parameters.Add(par);
        }
        string name = Convert.ToString(cmd.ExecuteScalar());
        cmd.Dispose();
        cn.Close();
        return name;
   
