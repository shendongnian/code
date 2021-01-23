    public static class GetFilteredData
    {
        public static DataTable FilterDataTable(this DataTable Dt, string FilterExpression)
        {
            using (DataView Dv = new DataView(Dt))
            {
                Dv.RowFilter = FilterExpression;
                return Dv.ToTable();
            }
        }
    }
    DataTableObject.FilterDataTable("Search Expression or your string variable")
