    public static class GetFilteredData
    {
        public static DataTable FilterDataTable(this DataSet Dt, string FilterExpression)
        {
            string Lowercase = FilterExpression.ToLower();
            Int16 TableID = 0;
            if (Lowercase.StartsWith("a"))
            {
                TableID = 0;
            }
            else if (Lowercase.StartsWith("b"))
            {
                TableID = 1;
            }
            else if (Lowercase.StartsWith("c"))
            {
                TableID = 2;
            }
            //upTo Z
            using (DataView Dv = new DataView(Dt.Tables[TableID]))
            {
                Dv.RowFilter = FilterExpression;
                return Dv.ToTable();
            }
        }
    }
