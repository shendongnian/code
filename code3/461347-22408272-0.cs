    using Microsoft.VisualBasic.FileIO;
    
            private static DataTable GetDataTableFromCsv(string path)
            {
                var dataTable = new DataTable("ImportData");
                var rows = File.ReadAllLines(path);
                var columns = rows[0].Split(',');
                foreach (var column in columns)
                {
                    dataTable.Columns.Add(new DataColumn(column.Trim(), typeof(string)));
                }
                using (var parser = new TextFieldParser(path))
                {
                    parser.Delimiters = new[] { "," };
                    while (true)
                    {
                        var parts = parser.ReadFields();
                        dataTable.Rows.Add(parts);
                        if (parser.EndOfData) break;
                    }
                }
                dataTable.Rows[0].Delete();
                return dataTable;
            }
