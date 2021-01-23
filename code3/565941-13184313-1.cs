    object valuesArray = new object[dataTable.Rows.Count, dataTable.Columns.Count];
    for(int i = 0; i < dt.Rows.Count; i++)
    {
        //If you know the number of columns you have, you can specify them this way
        //Otherwise use an inner for loop on columns
        valuesArray[i, 0] = dt.Rows[i]["ColumnName"].ToString();
        valuesArray[i, 1] = dt.Rows[i]["ColumnName2"].ToString();
        ...
    }
    //Calculate the second column value by the number of columns in your dataset
    //"O" is just an example in this case
    //Also note: Excel is 1 based index
    var sheetRange = worksheet.get_Range("A2:O2", 
        string.Format("A{0}:O{0}", dt.Rows.Count + 1));
    sheetRange.Cells.Value2 = valuesArray;
