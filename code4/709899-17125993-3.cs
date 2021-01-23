    string conString = "Provider=Microsoft.ACE.OLEDB.12.0;" + 
                       "Data Source=|DataDirectory|\\Manager.accdb;" + 
                       "Persist Security Info=False";
    string tableName = comboBox1.SelectedItem.ToString();
    using(OleDbConnection conn = new OleDbConnection (conString))
    using(OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + tableName + "]", conn))
    {
        con.Open();
        using(OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
        {
            DataSet ds = new DataSet();
            adapter.Fill(ds, tableName);  
            dataGridView.DataSource = ds.Tables[0];
        }
    }
