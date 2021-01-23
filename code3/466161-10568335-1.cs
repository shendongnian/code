    var requiredColumns = new HashSet<string>
        { "Name", "Type", "Phone", "Contract", "Remark" };
    if (datatable.Columns.Count != requiredColumns.Count) {
        Console.WriteLine("Number of columns does not match!");
    } else {
        for (int i = 0; i < datatable.Columns.Count; i++) {
            string colname = datatable.Columns[i].Name;
            if (!requiredColumns.Contains(colname)) {
                Console.WriteLine("Unknown column [{0}]", colname);
            }
        }  
    }
