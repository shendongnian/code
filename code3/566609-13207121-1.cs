    Enumerable.Range(0, tablePanel.RowCount)
        .Except(tablePanel.Controls.OfType<Control>()
        .Select(c => tablePanel.GetRow(c)))
        .OrderByDescending(i => i)
        .ToList()
        .ForEach(rowIndex =>
         {
             tablePanel.RowStyles.RemoveAt(rowIndex);
             tablePanel.RowCount--;
         });
