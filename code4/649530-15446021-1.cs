    StringBuilder sb = new StringBuilder();
	
	sb.Append("<table><tr>");
	
	foreach (DataColumn dc in dt.Columns)
	{
		sb.AppendFormat("<th>{0}</th>", dc.ColumnName);
	}
	
	sb.Append("</tr>");
	
	foreach (DataRow row in dt.Rows)
	{
		sb.Append("<tr>");
		
		foreach (DataColumn dc in dt.Columns)
			sb.AppendFormat("<td>{0}</td>", row[dc]);
		
		sb.Append("</tr>");
	}
	
	sb.Append("</table>");
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
        Response.Charset = "";
        Response.Write(sb.ToString())
