        public void ExportToExcel(DataTable table)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            //Begin Table
            context.Response.Write("<table><tr>");
            //Write Header
            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write("<th>" + column.ColumnName + "</th>");
            }
            context.Response.Write("</tr>");
            //Write Data
            foreach (DataRow row in table.Rows)
            {
                context.Response.Write("<tr>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    context.Response.Write("<td>" + row[i].ToString().Replace(",", string.Empty) + "</td>");
                }
                context.Response.Write("</tr>");
            }
            //End Table
            context.Response.Write("</table>");
            context.Response.ContentType = "application/ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=MyFileName.xls");
            context.Response.End();
        }
