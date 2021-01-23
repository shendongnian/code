    public void buildTable(string[] headers)
    {
        myGrid.Columns.Clear();
        foreach (string header in headers)
        {
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = header;
            myGrid.Columns.Add(c);
        }
    }
