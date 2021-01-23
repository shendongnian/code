    Remove()
    {
        int totalConnections  = ConGridView.RowCount;
        for (int i = 0; i < totalConnections ; i++)
        {
            if (ConGridView.Rows[i].Cells[0].Value.ToString() == Address)
            {
                ConGridView.Rows.RemoveAt(i);
                break;
            }
        }
    }
