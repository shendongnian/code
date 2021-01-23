    static class Extensions
    {
        public static string GetColumn(this DataRow Row, int Ordinal)
        {
            return Row.Table.Columns[Ordinal].ColumnName;
        }
    }
