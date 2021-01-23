    private void LogError(IfxException ex, IfxCommand query)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("{0}\n", query.CommandText));
        foreach (IDataParameter parameter in query.Parameters)
            sb.Append(String.Format("\t{0} = {1}\n",
                parameter.ParameterName, parameter.Value));
        LogError(ex, sb.ToString());
    }
