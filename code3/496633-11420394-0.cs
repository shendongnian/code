        protected static string ConstructReportJSON(ref DataTable dtResults)
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < dtResults.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < dtResults.Columns.Count; c++)
                {
                    sb.AppendFormat("\"{0}\":\"{1}\",", dtResults.Columns[c].ColumnName, dtResults.Rows[r][c].ToString());
                }
                sb.Remove(sb.Length - 1, 1); //Truncate the trailing comma
                sb.Append("},");
            }
            sb.Remove(sb.Length - 1, 1);
            return String.Format("[{0}]", sb.ToString());
        }
