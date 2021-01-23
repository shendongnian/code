         public string[] demo(string vpSchemaName, string vpTableName)
         {
            List<string> string_List = new List<string>();
             
            DataTable iDataTable = new DataTable();
            foreach (DataRow iDataRow in iDataTable.Rows)
            {
                string_List.Add(iDataRow["COLUMN_NAME"].ToString());
            }
            return string_List.ToArray();
        }
