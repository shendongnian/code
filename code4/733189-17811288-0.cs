    protected void ReBind(String sParameter)
    {
       SqlDataSource.SelectParameters.Remove(SqlDataSource.SelectParameters["parameterName"]);
       SqlDataSource.SelectParameters.Add("parameterName", sParameter);
       myGridView.DataBind();
    }
