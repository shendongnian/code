    try{
        DataTable dt = new DataTable();
        con.Open();
        dt.Load(new MySqlCommand("SELECT variant_name FROM tblVariant_Product WHERE product_name='" + cboProduct.Text + "'", con).ExecuteReader());
        dt.Columns.Add(new DataColumn("Quantity", typeof(Int32));
            
        DataRow row = dt.NewRow();
        row["variant_name"] = "TOTAL";
        row["quantity"] = 0;
        dt.Rows.Add(row);
        dataGridView2.DataSource = dt;
        con.Close();
     }
     catch (Exception)
     {
     }
