    public class CustomSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(ColumnModel column, IndentedTextWriter writer)
        {
            SetColumnDataType(column);
            base.Generate(column, writer);
        }
        private static void SetColumnDataType(ColumnModel column)
        {
            // xml type
            if (column.Annotations.ContainsKey("XmlType"))
            {
                column.StoreType = "xml";
            }
        }
    }
