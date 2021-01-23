            string connectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=D:\myDatabase.accdb;";
            string queryString = "SELECT Name AS FullName, Gender AS Gender, Address AS [Current Address] FROM Person";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            {
                try
                {
                    BindingSource bs = new BindingSource();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(queryString, connection);
                    OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bs.DataSource = dataTable;
                    dataGridView1.DataSource = bs;
                    bindingNavigator1.BindingSource = bs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
