    private void btnSave_Click(object sender, EventArgs e)
    {
        if (cmbStateCode.Text.ToString().Trim() == "" && txtCountryName.Text.ToString().Trim() == "")
        {
            MessageBox.Show("Please enter a valid data.", "Office Automation System", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        else
        {
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            // update your DataSet directly instead of this
            /*try
            {
                string Query;
                sqlCon.Open();
                if (isEditMode)
                    Query = "UPDATE NState SET CountryName='" + txtCountryName.Text.ToString().Trim() + "' WHERE CountryCode='" + cmbStateCode.Text + "'";
                else
                    Query = "INSERT INTO NState VALUES ('" + cmbStateCode.Text + "','" + txtCountryName.Text.ToString().Trim() + "')";
                SqlCommand sqlCmd = new SqlCommand(Query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                cmbStateCode.DropDownStyle = ComboBoxStyle.DropDownList;
                MessageBox.Show("Record saved successfully.", "Office Automation System", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                MessageBox.Show("Error occured while saving record.\nPlease check the StateCode for duplicate.", "Office Automation System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                sqlCon.Close();
            }*/
			
			SqlCommandBuilder builder = new SqlCommandBuilder(nStateTableAdapter1);
			if (isEditMode)
            {
				// update DataSet
				nStateTableAdapter1.UpdateCommand = builder.GetUpdateCommand();
			}			
            else
            {
				// insert value to DataSet
				nStateTableAdapter1.InsertCommand = builder.GetUpdateCommand();
			}
			
			nStateTableAdapter1.Adapter.Update(stateCodeDataSet, "NState");
	    
            // it's not necessary, ComboBox will have a new values	
            /*try
            {
                sqlCon.Open();
                fillStateInfo();
                nStateTableAdapter1.Adapter.Update(stateCodeDataSet, "NState");
                cmbStateCode.DataSource = nStateBindingSource1.DataSource;
                cmbStateCode.DisplayMember = "NState.CountryCode";
                cmbStateCode.ValueMember = "NState.CountryCode";
                cmbStateCode.Refresh();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlCon.Close();
            }*/
        }
	}
