    //Store the number of columns in a variable
    int columnCount = dataGridView.Columns.Count;
    
    //If we want the last column to fill the remaining space
    int lastColumnIndex = columnCount - 1;
    
    //Loop through each column and set the DataGridViewAutoSizeColumnMode
    //In this case, if we will set the size of all columns automatically, but have
    //the last column fill any extra space available.
    foreach(DataGridViewColumn column in dataGridView.Columns) 
    {
        if (column.Index == colCount - lastColumnIndex) //Last column will fill extra space
        {
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        else //Any other column will be sized based on the max content size
        {
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
    //Turn the scrollbars on for the DataGridView if needed
    dataGridView.ScrollBars = ScrollBars.Both;
