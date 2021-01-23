     public List<double> ExtractGridData(DataGridView grid)
        {
            int numCols = grid.Columns.Count;
            List<double> list = new List<double>();
            int i = 0;
            double[] cellsData = new double[numCols];
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                if(row.Cells[2].Value != null)
                {
                string value = row.Cells[2].Value.ToString();// third columnn of Grid as            //Example
                list.Add(Convert.ToDouble(value));
                }  
                
            }
            
            return list;
        }
