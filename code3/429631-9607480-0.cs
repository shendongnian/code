    public ActionResult Excel()
    {
        DataSet ds = ...
        using (var ms = new MemoryStream())  
        {
            ExcelLibrary.DataSetHelper.CreateWorkbook(ms, ds)
            return File(ms.ToArray(), "application/vnd.ms-excel", "demo.xls");
        }
    }
