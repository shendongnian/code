    DataGridView1.SelectionChanged += new EventHandler(DataGridView1_SelectionChanged);
    private void DataGridView1_SelectionChanged(object sender, EventArgs e){
        List<DataGridViewCell> toBeRemoved = new List<DataGridViewCell>();
        foreach(DataGridViewCell selectedCell in DataGridView1.SelectedCells){
            if (isCellUnSelectable(selectedCell))
                toBeRemoved.Add(selectedCell);
        }
        foreach(DataGridViewCell cell in toBeRemoved){
            cell.Selected = false;
        }
    }
