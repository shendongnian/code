    int column = 1; // Initialize for keys.
    foreach (string key in dict.Keys)
    {
        int row = 1; // Initialize for values in key.
        oSheet.Cells(row, column).Value = key;
        foreach (string value in dict[key])
        {
             row++;
             oSheet.Cells(row,column).Value = value;
        }
    
        column++; // increment for next key.
    }
