    public void ProcessDownload(HttpContext context, DataSet DataSource)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/vnd.ms-excel";
        MemoryStream file = getExcelMemStream(DataSource);
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "myFile.xls"));
        context.Response.BinaryWrite(file.GetBuffer());
        context.Response.End();
    }
