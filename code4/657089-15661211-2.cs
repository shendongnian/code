    void FormatTable(Table table)
    {
        table.BorderWidth = 2;
        table.BorderColor = Color.GloriousPink;
    }
    new List<Table>{ table1, table2 }.ForEach(FormatTable);
