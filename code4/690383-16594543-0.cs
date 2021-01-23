    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = "application/vnd.xls";
    Response.Charset = "UTF-8";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    // important !, send them as you make them.
    Response.Buffer = false;   
    
    for (int k = 0; k < dt.Columns.Count; k++)
    {
    	Response.Output.Write(dt.Columns[k].ColumnName);
        Response.Output.Write(',');
    }
    Response.Output.Write("\r\n");
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	for (int k = 0; k < dt.Columns.Count; k++)
    	{
    		Response.Output.Write(dt.Rows[i][k].ToString().Replace(",", ";"));
            Response.Output.Write(',');
    	}
    	Response.Output.Write("\r\n");
    }
