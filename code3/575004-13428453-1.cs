    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        String ConnString = @"Data Source=J-PC\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True";
        SqlConnection conn = new SqlConnection(ConnString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("select top 3 AddressID,AddressLine1,City,StateProvinceID,PostalCode from Person.Address ", conn);
        DataTable myDataTable = new DataTable();
        conn.Open();
        try
        {
            adapter.Fill(myDataTable);
        }
        finally
        {
            conn.Close();
        }
        if(myDataTable.Rows.Count < 5)
        {
            DataRow dr = null;
            for (int i = 0; i <= 5-myDataTable.Rows.Count ; i++)
            {
                myDataTable.Rows.Add(new object[]{});
            }
        }
        RadGrid1.DataSource = myDataTable;
    }
