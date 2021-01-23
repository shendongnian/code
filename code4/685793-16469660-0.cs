    // Get your DataSet from the database
    DataSet data = getMyDataSomeHow();
    // Create a blank row
    object[] newRow = new object[3]; // where "3" is the number of columns in your table
    newRow[0] = "";
    newRow[1] = "";
    newRow[2] = "";
    //Add the blank row
    data.Tables["myTable"].BeginLoadData();
    data.Tables["myTable"].LoadDataRow(newRow, true);
    data.Tables["myTable"].EndLoadData();
