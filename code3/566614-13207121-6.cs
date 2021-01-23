    var listOfAllRowIndices = Enumerable.Range(0, tablePanel.RowCount);
    var listOfControlsInTableLayoutPanel = tablePanel.Controls.OfType<Control>();
    var listOfRowIndicesWithControl = listOfControlsInTableLayoutPanel.Select(c => tablePanel.GetRow(c));
    var listOfRowIndicesWithoutControl = listOfAllRowIndices.Except(listOfRowIndicesWithControl);
    var listOfRowIndicesWithoutControlSortedInDescendingOrder = listOfRowIndicesWithoutControl.Reverse(); //or .OrderByDescending(i => i);
 
