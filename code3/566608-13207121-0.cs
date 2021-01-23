    private void RemoveEmptyRows()
    {
        for (int row = tablePanel.RowCount -1; row >= 0; row--)
        {
            bool hasControl = false;
            for (int col = 0; col < tablePanel.ColumnCount; col++)
            {
                if (tablePanel.GetControlFromPosition(col, row) != null)
                {
                    hasControl = true;
                    break;
                }
            }
            if (!hasControl)
            {
                tablePanel.RowStyles.RemoveAt(row);
                tablePanel.RowCount--;
            }
        }
    }
