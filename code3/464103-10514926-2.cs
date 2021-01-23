     private void Form1_Load(object sender, EventArgs e)
     {
        {
            String command = "SELECT * FROM Media";
            try
            {
                OleDbConnection myConnection = new OleDbConnection(access7ConnectionString);
                OleDbDataAdapter myAdapter = new OleDbDataAdapter(command,myConnection);
                DataTable myDataTable = new DataTable();
                myAdapter.Fill(myDataTable);
                DisplayRow(currentRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
