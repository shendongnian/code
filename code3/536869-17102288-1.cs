    //Best Way To read file direct from stream
    IExcelDataReader excelReader = null;
    //file.InputStream is the file stream stored in memeory by any ways like by upload file control or from database
    int excelFlag = 1; //this flag us used for execl file format .xls or .xlsx
    if (excelFlag == 1)
    {
        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
        excelReader = ExcelReaderFactory.CreateBinaryReader(file.InputStream);
    }
    else if(excelFlag == 2)                                
    {
        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
        excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
    }
    
    if (excelReader != null)
    {
        //...
        //3. DataSet - The result of each spreadsheet will be created in the result.Tables
        ds = excelReader.AsDataSet();
        //...
        ////4. DataSet - Create column names from first row
        //excelReader.IsFirstRowAsColumnNames = true;
        //DataSet result = excelReader.AsDataSet();
    
        ////5. Data Reader methods
        //while (excelReader.Read())
        //{
        //    //excelReader.GetInt32(0);
        //}
    
        //6. Free resources (IExcelDataReader is IDisposable)
        excelReader.Close();
    }
