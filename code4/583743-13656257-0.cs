    for (int i = ConGridView.RowCount - 1; i >= 0; i--)
    {
        if (ConGridView.Rows[i].Cells[0].Value.ToString() == Address)
        {
            ConGridView.Rows.RemoveAt(i);
             break;
        }
    }
