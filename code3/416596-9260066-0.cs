       //DataTable table = DataSet1.Tables["0"];
        // Presuming the DataTable has a column named Date.
        string expression;
        expression = "SENDER LIKE %"+TextBox1.Text+%";
        DataRow[] foundRows;
    
        // Use the Select method to find all rows matching the filter.
        foundRows = table.Select(expression); 
