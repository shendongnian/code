    private void numColsTextbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        int numCols;
        if (Int32.TryParse(tb.Text, out numCols))
        {
            myGrid.Columns.Clear();
            for (int i = 1; i <= numCols; i++)
            {
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = "Column " + i.ToString();
                myGrid.Columns.Add(c);
            }
        }
    }
