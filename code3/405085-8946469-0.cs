    // Create new ExcelFile.
    ExcelFile ef2 = new ExcelFile();
 
    // Imports all the tables from DataSet to new file.
    foreach (DataTable dataTable in dataSet.Tables)
    {
        // Add new worksheet to the file.
        ExcelWorksheet ws = ef2.Worksheets.Add(dataTable.TableName);
 
        // Change the value of the first cell in the DataTable.
        dataTable.Rows[0][0] = "This is new file!";
 
        // Insert the data from DataTable to the worksheet starting at cell "A1".
        ws.InsertDataTable(dataTable, "A1", true);
    }
 
    // Save the file to XLS format.
    ef2.SaveXls("DataSet.xls");
