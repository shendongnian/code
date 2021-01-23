    public ActionResult Import(HttpPostedFileBase file)
    {
        //HttpPostedFileBase directly is of no use so commented your code
        //var excel = new ExcelQueryFactory(file); //using linq to excel
        var stream = file.InputStream;
        if (stream.Length != 0)
        {
            //handle the stream here
            using (XLWorkbook excelWorkbook = new XLWorkbook(stream))
            {
                var name = excelWorkbook.Worksheet(1).Name;
                //do more things whatever you like as you now have a handle to the entire workbook.
                var firstRow = excelWorkbook.Worksheet(1).Row(1);
            }
        }
    }
    
