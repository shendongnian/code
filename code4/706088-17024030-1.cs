    String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Tables.accdb;Persist Security Info=True";
    string sql  = "SELECT Clients  FROM Tables";
    using(OleDbConnection conn = new OleDbConnection(connection))
    {
         conn.Open();
         DataSet ds = new DataSet();
         DataGridView dataGridView1 = new DataGridView();
         using(OleDbDataAdapter adapter = new OleDbDataAdapter(sql,conn))
         {
             adapter.Fill(ds);
             dataGridView1.DataSource = ds;
             // Of course, before addint the datagrid to the hosting form you need to 
             // set position, location and other useful properties. 
             // Why don't you create the DataGrid with the designer and use that instance instead?
             this.Controls.Add(dataGridView1);
         }
    }
