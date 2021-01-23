    private void monufactureComobobox_SelectedIndexChanged(object sender, EventArgs e)
    {
    
     string fecthManufacutreID= manufactureComobobox.selectedItem;
     DataSet ds = new DataSet();
    using (SqlConnection con = new SqlConnection(connection))
     {
        string myquery="Select modelid,name from modeltable where manufactuerid=@combox1Value";
        SqlCommand cmd = new SqlCommand(myquery, con);
        SqlDataAdapter dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        cmd.Parameters.Add("@combox1Value", SqlDbType.NVarChar, 15).Value = fecthManufacutreID;
        dap.Fill(ds);
        
      }
       ModelcomboBox.DataSource = ds.Tables[0];
       ModelcomboBox.ValueMember = "modelid";
       ModelcomboBox.DisplayMember = "name";
    
    }
