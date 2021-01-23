        public static List<string> GetSheetNames(string PathToExcelFile)
        {
            List<string> SheetNameList = new List<string>();
            System.Data.DataTable SchemaTable;
            string OleConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PathToExcelFile + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            using (System.Data.OleDb.OleDbConnection OleConnection = new System.Data.OleDb.OleDbConnection(OleConnectionString))
            {
                OleConnection.Open();
                SchemaTable = OleConnection.GetSchema("Tables");
                OleConnection.Close();
            }
            foreach (System.Data.DataRow SchemaRow in SchemaTable.Rows)
            {
                SheetNameList.Add(SchemaRow["TABLE_NAME"].ToString().TrimEnd('$'));
            }
            return SheetNameList;
        }
