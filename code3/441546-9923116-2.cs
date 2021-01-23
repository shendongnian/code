              /// <summary>
        /// This method retrieves the excel sheet names from 
        /// an excel workbook & reads the excel file
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        #region GetsAllTheSheetNames of An Excel File
        public static string[] ExcelSheetNames(String excelFile)
        {
            DataTable dt;
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties='Excel 12.0;HDR=Yes'";
            
            using (OleDbConnection objConn = new OleDbConnection(connString))
            {
                objConn.Open();
                dt =
                objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                string[] res = new string[dt.Rows.Count];
                for (int i = 0; i < res.Length; i++)
                {
                    string name = dt.Rows[i]["TABLE_NAME"].ToString();
                    if (name[0] == '\'')
                    {
                        //numeric sheetnames get single quotes around
                        //remove them here
                        if (Regex.IsMatch(name, @"^'\d\w+\$'$"))
                        {
                            name = name.Substring(1, name.Length - 2);
                        }
                    }
                    res[i] = name;
                }
                return res;
            }
        }
        #endregion
