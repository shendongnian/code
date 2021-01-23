    if (table != null && table.Columns.Count == 2)
    {
        table.Columns[0].Width = new GridLength(200);
        table.Columns[1].Width = new GridLength(200);
        document.Blocks.Add(table);
    }
