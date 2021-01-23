    //initiate a counter
    int totalWidth = 0;
    //Auto Resize the columns to fit the data
    foreach (DataGridViewColumn column in mydataGridView.Columns)
    {
        mydataGridView.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        int widthCol = mydataGridView.Columns[column.Index].Width;
        mydataGridView.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        mydataGridView.Columns[column.Index].Width = widthCol;
        totalWidth = totalWidth + widthCol;
    }
    //the selector on the left of the DataGridView is about 45 in width
    mydataGridView.Width = totalWidth + 45; 
     
