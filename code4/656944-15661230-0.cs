    public void RunChecks()
    {
        const int baseColumnCount = 3;
        for (int i = baseColumnCount; i < dataGrid.Columns.Count; i++)
        {
            foreach (DataGridRow row in Utilities.GetDataGridRows(dataGrid))
            {
                if (row != null)
                {
                    DataGridCell cell = dataGrid.GetCell(row, i);
                    // Start work with cell.
                    Color color;
                    TextBlock tb = cell.Content as TextBlock;
                    string cellValue = tb.Text;
                    if (!CheckForBalancedParentheses(cellValue))
                        color = (Color)ColorConverter.ConvertFromString("#FF0000");
                    else
                        color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
                    row.Background = new SolidColorBrush(color);
                    //cell.Background = new SolidColorBrush(color);
                }
            }
        }
    }
