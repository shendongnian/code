    public double[] ExtractGridData(DataGridView grid)
            {
                int numCells = grid.SelectedCells.Count;
                double[] cellsData = new double[numCells];
                int[] cellsKeys = new int[numCells];
                int cnt = 0;
                foreach (DataGridViewCell cell in grid.SelectedCells)
                {
                    if (cell.Value != null)
                    {
                        cellsData[cnt] = Convert.ToDouble(cell.Value);
                        cellsKeys[cnt] = cell.RowIndex + cell.ColumnIndex * grid.ColumnCount;
                        cnt++;
                    };
    
                }
                Array.Sort(cellsKeys, cellsData);
                return cellsData;
            }
