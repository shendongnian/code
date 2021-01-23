    const int maxInvoiceLength = 10;
    string fileName = @"C:\temp\fs.txt";
    string dir = Path.GetDirectoryName(fileName);
    DataTable dataTable;
    using (OleDbConnection conn =
        new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;" +
            "Data Source=" + dir + ";" +
            "Extended Properties=\"Text;\""))
        {
            conn.Open();
            string query = String.Format("SELECT RecordTypeSCFBody, LEFT(InvoiceNumber + SPACE({0}), {0}), Amount FROM {1}", maxInvoiceLength, fileName);
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
        }
        Console.Write(dataTable.Rows[0][1].ToString());
