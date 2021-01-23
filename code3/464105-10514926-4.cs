     private void Form1_Load(object sender, EventArgs e)
     {
        {
            string command = "SELECT * FROM Media";
            currentRecord=0
            try
            {
                OleDbConnection myConnection = new OleDbConnection(access7ConnectionString);
                //add the open and close methods for the connection, I am pretty sure they are needed
                myConnection.Open();
                OleDbDataAdapter myAdapter = new OleDbDataAdapter(command,myConnection);
                DataTable myDataTable = new DataTable();
                myAdapter.Fill(myDataTable);
                myConnection.Close();
                DisplayRow(currentRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
