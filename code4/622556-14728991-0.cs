    da = new SqlDataAdapter("select * from Measurement", con);
    SqlCommandBuilder cb = new SqlCommandBuilder(da);
    dr = dt.Select(" ID = " + txtID.Text)[0];
    
    if (txtCellNo.Text == "")
    {
      MessageBox.Show("Please enter Cell Number");
    }
    else if (dr["CellNumber"] != "")
    {
      dr["CellNumber"] = txtCellNo.Text.Trim();
      dr["FirstName"] = txtFirstName.Text;
      dr["LastName"] = txtLastName.Text;
      dr["Shirt"] = txtShirt.Text;
      dr["Pant"] = txtPant.Text;
      dr["DueDate"] = txtDueDate.Text;
      dr["Date"] = txtDate.Text;
     }
     try
     {
       da.Update(ds, "Measurement");
     }
     catch (DBConcurrencyException ex)
     {
       MessageBox.Show(ex.Message);
     }
