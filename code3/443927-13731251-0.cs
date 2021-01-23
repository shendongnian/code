        public string ConvertDataTableToString(DataTable table)
        {
            int iColumnCount = table.Columns.Count;
            int iRowCount = table.Rows.Count;
            int iTempRowCount = 0;
            string strColumName = table.Columns[0].ColumnName;
            string strOut = "{";
            foreach (DataRow row in table.Rows) 
            {
                strOut = strOut + "{";
                foreach (DataColumn col in table.Columns)
                {
                    string val = row.Field<string>(col.ColumnName);
                    strOut = strOut + col.ColumnName + ":" + val;
                    if (col.Ordinal != iColumnCount - 1)
                    {
                        strOut = strOut + ",";
                    }
                }
                strOut = strOut + "}";
                iTempRowCount++;
                if (iTempRowCount != iRowCount)
                {
                    strOut = strOut + ",";
                }
            }
            strOut = strOut + "}";
            return strOut;
        }
