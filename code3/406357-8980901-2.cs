    private static SqlParameter AddNewParameterToCommand(SqlCommand command,
        string name, object value, bool isOutputParameter)
    {
        SqlParameter parm = new SqlParameter();
        parm.ParameterName = name;
        parm.Value = value;
        if (isOutputParameter)
        {
            parm.Direction = ParameterDirection.InputOutput;
        }
        command.Parameters.Add(parm);
        return parm;
    } 
