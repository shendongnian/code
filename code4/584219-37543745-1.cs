    public void ExporttoExcel(DataTable table, string filename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=GridData.xlsx");
        using (ExcelPackage pack = new ExcelPackage())
        {
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);
            ws.Cells["A1"].LoadFromDataTable(table, true);
            var ms = new System.IO.MemoryStream();
            pack.SaveAs(ms);
            ms.WriteTo(HttpContext.Current.Response.OutputStream); 
        }
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
