    Settings.UpdateColumn = (Column column, Table table) =>
    {
            if (table.Name.Equals("Quote", StringComparison.InvariantCultureIgnoreCase)
                && column.Name.Equals("Quote_Number", StringComparison.InvariantCultureIgnoreCase))
            {
                column.IsStoreGenerated = true;
            }
    }
