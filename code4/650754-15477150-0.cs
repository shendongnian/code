    if (upprice.FileName.Contains(".xlsx"))
     {
      IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
       DataSet result = excelReader.AsDataSet();
     }
     else if (upprice.FileName.Contains(".xls"))
     {
      IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
      DataSet result = excelReader.AsDataSet();
     } 
