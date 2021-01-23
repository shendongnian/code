    Response.ContentType = "application/vnd.ms-excel";
    Response.AppendHeader("Content-Disposition", "attachment; filename=translationText.xls");
    Response.Write("<table>");
    for (int i = 1; i <= 100; i++)
    {
        Response.Write("<tr>");
        for (int j = 1; j < 100; j++)
        {
            Response.Write("<td>"+i + "  : " + j+"</td>");            
        }
        Response.Write("</tr>");
    }
    Response.Write("</table>");
    Response.Flush();
    Response.End();
