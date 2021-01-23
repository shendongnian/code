    MySqlConnection conn = new MySqlConnection(connectionstring);          
    conn.Open();
    string stmt = "SELECT DealerName, OrderId, DealerId, OrderDate, ItemType, Price, Quantity,
    Total, TotalBill FROM dbo.DetailedRecord where DealerName=ComboboxName.SelectedValue";
    DataSet ds = new DataSet();
    MySqlDataAdapter da = new MySqlDataAdapter(stmt, conn);
    da.Fill(ds, "Authors");           
    dataGridView1.DataSource = ds.Tables["Authors"];
