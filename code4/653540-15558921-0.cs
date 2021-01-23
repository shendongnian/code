    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        foreach (DbParameter P in e.Command.Parameters)
        {
            Response.Write(P.ParameterName + "<br />");
            Response.Write(P.DbType.ToString() + "<br />");
            Response.Write(P.Value.ToString() + "<br />");
        }
    }
