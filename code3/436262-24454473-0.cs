      public static string ToHTML(this DataTable dt, Func<DataRow, bool> rowHiglithRule)
        {
            if (dt == null) throw new ArgumentNullException("dt");
            string tab = "\t";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(tab + tab + "<table>");
            // headers.
            sb.Append(tab + tab + tab + "<thead><tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", dc.ColumnName);
            }
            sb.AppendLine("</thead></tr>");
            // data rows
            foreach (DataRow dr in dt.Rows)
            {
                if (rowHiglithRule != null)
                {
                    if (rowHiglithRule(dr))
                    {
                        sb.Append(tab + tab + tab + "<tr class=\"highlightedRow\">");
                    }
                    else
                    {
                        sb.Append(tab + tab + tab + "<tr>");
                    }
                }
                else
                {
                    //Non ho alcuna regola, quindi caso normale.
                    sb.Append(tab + tab + tab + "<tr>");
                }
                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td>{0}</td>", cellValue);
                }
                sb.AppendLine("</tr>");
            }
            sb.AppendLine(tab + tab + "</table>");
            return sb.ToString();
        }
