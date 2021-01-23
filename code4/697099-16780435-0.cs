    public static class DataRowExtensions
    {
        public static int IndexIn(this DataRow thisRow, DataTable table)
        {
            return table.Rows
                .OfType<DataRow>()
                .Select((row, i) => new { row, index = i + 1 })
                .Where(pair => EqCondition(thisRow, pair.row))
                .Select(pair => pair.index)
                .FirstOrDefault() - 1;
        }
        public static bool EqCondition(DataRow row1, DataRow row2)
        {
            // check for the equality of row values
            return true;
        }
    }
    ...
    for (int i = 0; i < tab1.Rows.Count; i++)
    {
        var index = tab1.Rows[i].IndexIn(tab2);
        if (index < 0)
        {
            Console.WriteLine("The row at index {0} was not found in second table", i);
        }
        else
        {
            Console.WriteLine("The row at index {0} was found in second table at index", i, index);
        }
    }
