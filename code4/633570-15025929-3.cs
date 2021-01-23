    class Program
    {
        static void Main(string[] args)
        {
            // DataTable bonus! :)
            System.Data.DataTable dt = new System.Data.DataTable();
            // read the header first
            var header = GetData(true);
            foreach (var column in header.First())
            {
                dt.Columns.Add(column.ToString());
            }
            // read the rows
            var rows = GetData(false);
            foreach (var row in rows)
            {
                dt.Rows.Add(row.ToArray());
            }
        }
        private static IEnumerable<List<object>> GetData(bool readHeader)
        {
            string query = "SELECT * FROM [List1$]";
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=c:\Temp\Test.xls;Extended Properties=""Excel 12.0 Xml;HDR=NO;IMEX="
                + ((readHeader) ? "1" : "0") + @";""";
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        bool isHeaderRead = false;
                        while (reader.Read())
                        {
                            if (readHeader && isHeaderRead)
                            { break; }
                            isHeaderRead = true;
                            List<object> values = new List<object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                values.Add(reader.GetValue(i));
                            }
                            yield return values;
                        }
                    }
                }
            }
        }
    }
