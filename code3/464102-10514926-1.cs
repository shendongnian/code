    private void Form1_Load(object sender, EventArgs e)
    {
        {
            String command = "SELECT * FROM Media";
            try
            {
                //you create a connection 
                myConnection = new OleDbConnection( access7ConnectionString );
                // you create an adapter, which uses the connection string again?  
                //that is odd to me, are you sure this is correct
                myAdapter = new OleDbDataAdapter(access7ConnectionString, myConnection);
                // your command builder uses the adapter but not the command
                myCommandBuilder = new OleDbCommandBuilder(myAdapter);
                //you create a datatable but never add anything to it?
                myDataTable = new DataTable();
                // FillDataTable I can't find but it is not assigned to anything 
                //and only uses the command not the connection or adapter
                FillDataTable(command);
                DisplayRow(currentRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
