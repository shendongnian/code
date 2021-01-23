        SqlDataSource dsProdDocsHeader = new SqlDataSource(utils.Conn(Server.MachineName), SQL_PROD_DOCS);
        DataView dvsqllist = (DataView)dsProdDocsHeader.Select(DataSourceSelectArguments.Empty);
        DataTable tablelist = dvsqllist.Table;
        int n = tablelist.Rows.Count;
        if (n > 0)
        {
           RptrProductDocs.DataSource = dsProdDocsHeader.Select(DataSourceSelectArguments.Empty);
           RptrProductDocs.DataBind();
        }
        else
        {
           // whatever u want to show.
        }
