    public static bool ToExcelFile(this DataTable dt, string filename)
    {
        bool Success = false;
        //try
        //{
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt, "Sheet 1");
            if (filename.Contains("."))
            {
                int IndexOfLastFullStop = filename.LastIndexOf('.');
                filename = filename.Substring(0, IndexOfLastFullStop) + ".xlsx";
            }
            filename = filename + ".xlsx";
            wb.SaveAs(filename);
            Success = true;
        //}
        //catch (Exception ex)
        //{
            //ex.HandleException();
        //}
        return Success;
    }
