    final oldValue = dataGridView.Columns[row][2];
    try
    {
        dataGridView.Columns[3][i] = ...
    }  
    catch(System.FormatException e)
    {
        // Set cell back to old value.
        dataGridView.Columns[row][2] = oldValue;
    }
