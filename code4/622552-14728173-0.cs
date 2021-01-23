    private void btnSave_Click_1(object sender, EventArgs e)
    {
        da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand("select * from Measurement where ID = @ID",con);
        da.SelectCommand.Parameters.AddWithValue("@ID",txtID.Text);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        da.Fill(ds, "Measurement");
        dr = da.Tables["Measurement"].Rows[0];
        dr["CellNumber"] = txtCellNo.Text.Trim();
        dr["FirstName"] = txtFirstName.Text;
        dr["LastName"] = txtLastName.Text;
        dr["Shirt"] = txtShirt.Text;
        dr["Pant"] = txtPant.Text;
        dr["DueDate"] = txtDueDate.Text;
        dr["Date"] = txtDate.Text;
        
        if (dr["CellNumber"] == "")
        {
            MessageBox.Show("Please enter Cell Number");
        }
        else
        {
            try
            {
               cb.GetUpdateCommand();
               da.Update(ds, "Measurement");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
  
      }
