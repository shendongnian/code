    private DataTable GetDataTableFromCsv(string path)
        {
            DataTable dataTable = new DataTable();
            String[] csv = File.ReadAllLines(path);
            foreach (string csvrow in csv)
            {
                var fields = csvrow.Split(','); // csv delimiter
                var row = dataTable.NewRow();
                row.ItemArray = fields;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
