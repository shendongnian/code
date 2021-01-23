    DataTable copyDataTable = dataTable.Copy();
    copyDataTable.AsEnumerable().Where(c => c["columnName"].ToString().Equals("Y"))
             .ToList().ForEach(c => c["columnName"] = "Yes");
    copyDataTable.AsEnumerable().Where(c => c["columnName"].ToString().Equals("N"))
             .ToList().ForEach(c => c["columnName"] = "No");
