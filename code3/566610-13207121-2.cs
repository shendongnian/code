    var listOfAllRowIndices = Enumerable.Range(0, tablePanel.RowCount);
    var listOfControlsInTableLayoutPanel = tablePanel.Controls.OfType<Control>();
    var listOfRowIndicesWithControl = listOfControlsInTableLayoutPanel.Select(c => tablePanel.GetRow(c));
    var listOfRowsWithoutControl = listOfAllRowIndices.Except(listOfRowIndicesWithControl);
    var listOfRowsWithoutControlSortedInDescendingOrder = listOfRowsWithoutControl.OrderByDescending(i => i);
 
