    SqlParameter param  = new SqlParameter();
    param.ParameterName = "@user";
    param.Value         = User.Identity.Name.ToString();
    param.DbType        =  SqlDbType.VarChar;
    command.Parameters.Add(param);
