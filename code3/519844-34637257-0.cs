    private void AddARow(DataSet dataSet)
    {
        DataTable table;
        table = dataSet.Tables["Suppliers"];
        // Use the NewRow method to create a DataRow with 
        // the table's schema.
        DataRow newRow = table.NewRow();
    
        // Set values in the columns:
        newRow["CompanyID"] = "NewCompanyID";
        newRow["CompanyName"] = "NewCompanyName";
    
        // Add the row to the rows collection.
        table.Rows.Add(newRow);
    }
