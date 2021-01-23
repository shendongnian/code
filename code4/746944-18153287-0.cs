    SqlDataSource dsProdDocsHeader = new SqlDataSource(utils.Conn(Server.MachineName), SQL_PROD_DOCS);
    DataView view = (DataView)dsProdDocsHeader.Select(DataSourceSelectArguments.Empty);
        if (view.Count == 0)
        {
            lblMessage.Text = "Message!!!";
        }
        else
	    {
            RptrProductDocs.DataSource = view;
            RptrProductDocs.DataBind();
	    }
