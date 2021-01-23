    private void DataExport()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Title = "Choose file to save to",
            FileName = ".csv",
            Filter = "CSV (*.csv)|*.csv",
            FilterIndex = 0,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        };
    
        if (!saveFileDialog.ShowDialog())
        {
            return;
        }
    
        using (var conn = new SQLiteConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT * FROM Tile1";
            using (var reader = cmd.ExecuteReader())
            using (var writer = new StreamWriter(saveFileDialog.FileName))
            {
                var columnNames = Enumerable
                    .Range(0, reader.FieldCount)
                    .Select(reader.GetName);
                string header = string.Join(", ", columnNames);
                writer.WriteLine(header);
                while (reader.Read())
                {
                    var values = Enumerable
                        .Range(0, reader.FieldCount)
                        .Select(reader.GetValue);
                    string valuesRow = string.Join(", ", values);
                    writer.WriteLine(valuesRow);
                }
            }
        }
    }
