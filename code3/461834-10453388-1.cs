    public static class DataTableQuery
    {
        public static IEnumerable<DataRow> Where(this DataTable dataTable, string columnName, string expression) {
            return from dr in dataTableToPage.AsEnumerable()
                         where dr[columnToFilter].ToString() == expression
                         select dr;
        }
        
        public static IEnumerable<DataRow> Like(this DataTable dataTable, string columnName, string expression) {
            return from dr in dataTableToPage.AsEnumerable()
                         where dr[columnToFilter].ToString().IndexOf(expression, StringComparison.OrdinalIgnoreCase) >= 0
                         select dr;
        }
    }
