    Enumerable.Range(0, tablePanel.RowCount)
        .Except(tablePanel.Controls.OfType<Control>()
            .Select(c => tablePanel.GetRow(c)))
        .Reverse()
        .ToList()
        .ForEach(rowIndex =>
         {
             tablePanel.RowStyles.RemoveAt(rowIndex);
             tablePanel.RowCount--;
         });
