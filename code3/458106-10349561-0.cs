    private void Load(string sql) {
        if (connection.State != System.Data.ConnectionState.Open) {
            connection.Open();
        }
        using (SqlCeCommand command = new SqlCeCommand(sql, connection)) {
            using (SqlCeDataReader reader = command.ExecuteReader()) {
                DataSet dataSet = new DataSet();
                    
                dataSet.Tables.Add("items");
                while (reader.Read()) {
                    DataRow row = new DataRow();
                    // fill your row
                    dataSet.Tables["items"].Rows.Add(row);
                }
                BindingSource binding = new BindingSource(dataSet, "items");
                grid.DataSource = binding;
            }
        }
    }
