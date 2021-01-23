    private void monufactureComobobox_SelectedIndexChanged(object sender, EventArgs e)
    {
    
     string fecthManufacturerID= manufactureComobobox.selectedItem;
     DataTable dtModel = new DataTable();
     dtModel= ModelComboPopulate(fecthManufacturerID);
     ModelcomboBox.DataSource = dtModel;
     ModelcomboBox.ValueMember = "modelid";
     ModelcomboBox.DisplayMember = "name";
    
    }
    public DataTable ModelComboPopulate(string ID)
    {
     DataSet ds = new DataSet();
     using (SqlConnection con = new SqlConnection(connection))
     {
        string myquery="Select modelid,name from modeltable where manufacturerid=@combox1Value";
        SqlCommand cmd = new SqlCommand(myquery, con);
        SqlDataAdapter dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        cmd.Parameters.Add("@combox1Value", SqlDbType.NVarChar, 15).Value = ID;
        dap.Fill(ds);
        return ds.Tables[0];
      }
    
    }
