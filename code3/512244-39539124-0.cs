            //Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            
            // DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            while (excelReader.Read())
            {    // Reading from row and get columns by index           
                var test = excelReader.GetString(1);
                
            }
