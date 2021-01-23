    public static DataTable TableToDataTable( string msiPath, string tableName )
    {
        DataTable dataTable = null;
        using(var database = new Database(msiPath, DatabaseOpenMode.ReadOnly))
        {
            using(var view = database.OpenView("SELECT * FROM `{0}`", tableName))
            {
                view.Execute();
                dataTable = new DataTable(tableName);
                foreach (var column in view.Columns)
                {
                    dataTable.Columns.Add(column.Name, column.Type);
                }
                foreach (var record in view) using (record)
                {
                    var row = dataTable.NewRow();
                    foreach (var column in view.Columns)
                    {
                        row[column.Name] = record[column.Name];
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }
        return dataTable;
    }
