            private static void ImportValueSetAttributeFile(string filePath)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();
            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            var connectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            var database = ConfigurationManager.AppSettings["database"];
            var mongoAccess = new MongoDataAccess(connectionString, database);
            var cdm = new BaseDataManager();
            int ind = 0;
            for (int i = 0; i < result.Tables.Count; i++)
            {
                int row_no = 1;
                while (row_no < result.Tables[ind].Rows.Count) // ind is the index of table
                    // (sheet name) which you want to convert to csv
                {
                    var currRow = result.Tables[ind].Rows[row_no];
                    var valueSetAttribute = new ValueSetAttribute()
                        {
                            CmsId = currRow[0].ToString(),
                            NqfNumber = currRow[1].ToString(),
                            ValueSetName = currRow[2].ToString(),
                            ValueSetOid = currRow[3].ToString(),
                            Definition = currRow[4].ToString(),
                            QdmCategory = currRow[5].ToString(),
                            Expansion = currRow[6].ToString(),
                            Code = currRow[7].ToString(),
                            Description = currRow[8].ToString(),
                            CodeSystem = currRow[9].ToString(),
                            CodeSystemOid = currRow[10].ToString(),
                            CodeSystemVersion = currRow[11].ToString()
                        };
                    cdm.AddRecords<ValueSetAttribute>(valueSetAttribute, "ValueSetAttributes");
                    row_no++;
                }
                ind++;
            }
        }
