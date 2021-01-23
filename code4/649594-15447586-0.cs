    List<double> cellsData = new List<double>();
    foreach (DataGridViewCell cell in grid.SelectedCells)
    {
        if( cell.Value != null)
            cellsData.Add(Convert.ToDouble(cell.Value));
    }
