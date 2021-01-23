    FileStream stream = null;
    IExcelDataReader excelReader = null;
    DataSet excelDataSet = null;
    
    using (stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
    {
        if (filePath.EndsWith(".xlsx"))
        {
            //Reading from a OpenXml Excel file (2007 format; *.xlsx)
            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        }
        else //.xls
        {
            //Reading from a binary Excel file ('97-2003 format; *.xls)
            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        }
        excelReader.IsFirstRowAsColumnNames = true;
        excelDataSet = excelReader.AsDataSet();
    }
