    public class ExporFile
    {
        /// <summary>
        /// Export to CSV
        /// </summary>
        /// <param name="exportTable">Export table</param>
        /// <param name="showColumns">Columns needs to show in CSV</param>
        /// <param name="changedColumnName">Changed Column Names in CSV</param>
        /// <param name="fileName">File Name</param>
        public static void ExportCSV(DataTable exportTable, string showColumns, string changedColumnName, string fileName)
        {
            DataTable filterTable = FilterColumn(exportTable, showColumns, changedColumnName);
            string dataCSV = DataTable2CSV(filterTable, "\t", "\"");
            dataCSV = System.Web.HttpContext.Current.Server.HtmlDecode(dataCSV);
            System.Web.HttpContext.Current.Response.Charset = "";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            System.Web.HttpContext.Current.Response.Write(dataCSV);
            System.Web.HttpContext.Current.Response.Flush();
            try
            {
                System.Web.HttpContext.Current.Response.End();
            }
            catch { };
        }
        /// <summary>
        /// Filter Columns
        /// </summary>
        /// <param name="exportTable"></param>
        /// <param name="showColumns"></param>
        /// <param name="changedColumnName"></param>
        /// <returns></returns>
        private static DataTable FilterColumn(DataTable exportTable, string showColumns, string changedColumnName)
        {
            DataView filterDataView = exportTable.DefaultView;
            //filterDataView.Sort = "AutoID";
            DataTable filterTable = filterDataView.ToTable(false, showColumns.Split(','));
            return ChangedExportDataColumnName(filterTable, changedColumnName);
        }
        /// <summary>
        /// Changed Column Datatable
        /// </summary>
        /// <param name="filterTable"></param>
        /// <param name="changedColumnName"></param>
        /// <returns></returns>
        private static DataTable ChangedExportDataColumnName(DataTable filterTable, string changedColumnName)
        {
            string[] changedNames = changedColumnName.Split(',');
            for (int i = 0; i < changedNames.Length; i++)
            {
                if (!String.IsNullOrEmpty(changedNames[i]))
                {
                    filterTable.Columns[i].ColumnName = changedNames[i];
                }
            }
            return filterTable;
        }
        /// <summary>
        /// Returns a CSV string corresponding to a datatable. However the separator can be defined and hence it can be any string separated value and not only csv.
        /// </summary>
        /// <param name="table">The Datatable</param>
        /// <param name="separator">The value separator</param>
        /// <param name="circumfix">The circumfix to be used to enclose values</param>
        /// <returns></returns>
        private static String DataTable2CSV(DataTable table, string separator, string circumfix)
        {
            StringBuilder builder = new StringBuilder(Convert.ToString((char)65279));
            foreach (DataColumn col in table.Columns)
            {
                builder.Append(col.ColumnName).Append(separator);
            }
            builder.Remove((builder.Length - separator.Length), separator.Length);
            builder.Append(Environment.NewLine);
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    builder.Append(circumfix).Append(row[col.ColumnName].ToString().Replace("\"", "\"\"")).Append(circumfix).Append(separator);
                }
                builder.Remove((builder.Length - separator.Length), separator.Length);
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
