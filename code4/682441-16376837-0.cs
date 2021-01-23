    public List<double[]> ExtractGridData(DataGridView grid)
            {
                int numCols = grid.Columns.Count;
                List<double[]> list = new List<double[]>();
                    int i=0;
                    double[] cellsData = new double[numCols];
                    foreach (DataGridViewCell cell in grid.SelectedCells)
                    {
                       
                        if (cell.Value != null)
                            {
                             cellsData[i] = Convert.ToDouble(cell.Value);
                             i++;
                             }
                            
                    }
                   list.Add(cellsData);
        
                return list;
            }
