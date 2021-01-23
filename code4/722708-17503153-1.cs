        public string[]  m_DEMO_Return_var_method(string vpSchemaName, string vpTableName)
        {
            var var_List = new List<string>();
            DataTable iDataTable = new DataTable();
            var_List.Clear();
            foreach (DataRow iDataRow in iDataTable.Rows)
            {
                var_List.Add(iDataRow["COLUMN_NAME"].ToString());
            }
            var vColumnName = var_List.ToArray();
            return vColumnName;
      }
