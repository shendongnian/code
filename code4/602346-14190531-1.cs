      public static void DataTable2CSV(DataTable table, string filename, string seperateChar)
        {
            StreamWriter sr = null;
            try
            {
                sr = new StreamWriter(filename);
                string seperator = "";
                StringBuilder builder = new StringBuilder();
                foreach (DataColumn col in table.Columns)
                {
                    builder.Append(seperator).Append(col.ColumnName);
                    seperator = seperateChar;
                }
                sr.WriteLine(builder.ToString());
                foreach (DataRow row in table.Rows)
                {
                    seperator = "";
                    builder = new StringBuilder();
                    foreach (DataColumn col in table.Columns)
                    {
                        builder.Append(seperator).Append(row[col.ColumnName]);
                        seperator = seperateChar;
                    }
                    sr.WriteLine(builder.ToString());
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        } 
