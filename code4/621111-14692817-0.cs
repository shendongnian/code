    private static void ExportToExcel(string data)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"" + filename + ".csv\"");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.Write(data);
        HttpContext.Current.Response.End();
    }
