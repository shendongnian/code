    public static class JSONEncoderHelper
    {
        public static string FromXML(DataTable table)
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.Append("{\"");
            sbuilder.Append(table.TableName);
            sbuilder.Append("\":[");
            bool first = true;
            foreach (DataRow drow in table.Rows)
            {
                if (first)
                {
                    sbuilder.Append("{");
                    first = false;
                }
                else
                    sbuilder.Append(",{");
                bool firstColumn = true;
                foreach (DataColumn column in table.Columns)
                {
                    if (firstColumn)
                    {
                        sbuilder.Append(string.Format("\"{0}\":\"{1}\"", column.ColumnName, drow[column].ToString()));
                        firstColumn = false;
                    }
                    else
                    sbuilder.Append(string.Format(",\"{0}\":\"{1}\"", column.ColumnName, drow[column].ToString()));
                }
                sbuilder.Append("}");
            }
            sbuilder.Append("]}");
            return sbuilder.ToString();
        }
    }
