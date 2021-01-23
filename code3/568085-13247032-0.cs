    public override void ExecuteResult(ControllerContext context)
    {
        HttpContext curContext = HttpContext.Current;
        curContext.Response.Clear();
        curContext.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        curContext.Response.Charset = "";
        curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        curContext.Response.ContentType = "application/vnd.ms-excel";
        StringBuilder sb = new StringBuilder();
        sb.Append("<font size=6>COMPANY<font>");
        sb.Append("</br>");
        ExcelGridView.HeaderStyle.BackColor = Color.Orange;
        ExcelGridView.RenderControl(htw);
        ExcelGridView.Rows[2].
        sb.Append("<table border=1 bgcolor=#DBA901>");
        sb.Append("<tr >");
        sb.Append("<td>");
        sb.Append("Total");
        sb.Append("</td>");
        sb.Append("<td colspan=1>");
        sb.Append(totalQ);
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("</td>");
        sb.Append("<td  style=mso-number-format:.00>");
        sb.Append(totalP);
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<table>");
        byte[] byteArray = Encoding.ASCII.GetBytes(sb.ToString());
        MemoryStream s = new MemoryStream(byteArray);
        StreamReader sr = new StreamReader(s, Encoding.ASCII);
        curContext.Response.Write(sr.ReadToEnd());
        curContext.Response.End();
    }
