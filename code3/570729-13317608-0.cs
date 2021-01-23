     SqlParameter param;
        param = new SqlParameter("username", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value = userNameTB;
        cmd.Parameters.Add(param);
