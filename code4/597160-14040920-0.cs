    public class ExcelUtility
    {
        public static void ToExcel(object dataSource)
        {
            GridView grid = new GridView { DataSource = dataSource };
            grid.DataBind();
            StringBuilder sb = new StringBuilder();
            foreach (TableCell cell in grid.HeaderRow.Cells)
                sb.Append(string.Format("\"{0}\",", cell.Text));
            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
            foreach (GridViewRow row in grid.Rows)
            {
                foreach (TableCell cell in row.Cells)
                    sb.Append(string.Format("\"{0}\",", cell.Text.Trim().Replace("&nbsp;", string.Empty)));
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();
            }
            ExportToExcel(sb.ToString());
        }
        private static void ExportToExcel(string data)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Report.csv");
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.Write(data);
            HttpContext.Current.Response.End();
        }
    }
