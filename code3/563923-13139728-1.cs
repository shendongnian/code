    Table table = new Table();
    TableRow headerRow = new TableRow();
    foreach(string field in fields)
    {
        TableCell headerCell = new TableCell();
        headerCell.Text = field;
        headerRow.Controls.Add(headerCell);
    }
    foreach(SPListItem li in listItemColl)
    {
        TableRow dataRow = new TableRow();
        foreach(string field in fields)
        {
            TableCell dataCell = new TableCell();
            dataCell.Text = li[field].ToString();
            dataRow.Controls.Add(dataCell);
        }
    }
    plhDirRankings.Controls.Add(table);
