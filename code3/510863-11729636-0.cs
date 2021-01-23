    private void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
    		var description = txtbox1.Text.Trim();
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Description is required.");
    			return;
            }
    		var abbr = txtbox2.Text.Trim();
            if (string.IsNullOrEmpty(abbr))
            {
                MessageBox.Show("Abbr is required.");
    			return;
            }
            var numericOrderValue = Convert.ToDecimal(numericOrder.Value);
            if (SortOrders.Contains(numericOrderValue)
            {
                MessageBox.Show("Please select another one, this one is already used.");
    			return;
            }
            DataRow dr = mydataSet.Tables[0].NewRow();
            dr["Descript"] = description;
            dr["Abbr"] = abbr;    		
            dr["SortOrder"] = numericOrderValue;            
            mydataSet.Tables[0].Rows.Add(dr);
            dgv.DataSource = mydataSet.Tables[0];
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
