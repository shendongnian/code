    string connectionString = 
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;"
        + "User Id=admin;Password=password;";
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        adapter.SelectCommand = new OleDbCommand("SELECT * FROM MyTable", connection);
        OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
        connection.Open();
        DataRow dataRow = myDataset.Tables["salam"].NewRow();
        dataRow[1] = textBox2.Text;
        dataRow[2] = textBox3.Text;
        dataRow[3] = textBox4.Text;
        dataRow[4] = textBox5.Text;
        myDataset.Tables["salam"].Rows.Add(dataRow);
        oleDbDataAdabter.Update(myDataset , "salam");
    }
