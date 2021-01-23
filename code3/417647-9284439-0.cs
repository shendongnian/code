    IE browser = new IE();
    browser.GoTo("[yourURL]");
    Table theTable = browser.Table(Find.ByClass("TABLEBORDER"));
    for (int i = 1; i < theTable.OwnTableRows.Count; i++)
    {
        Console.WriteLine("column value:" + theTable.OwnTableRows[i].TableCells[3].Text);
    }
