    private void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            bool error = false;
            if (txtbox1.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Description is required.");
                error = true;
            }
            if (txtbox2.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Abbr is required.");
                error = true;
            }
            if (SortOrders.Contains(Convert.ToDecimal(numericOrder.Value)
            {
                MessageBox.Show("Please select another one, this one is already used.");
                error = true;
            }
            if(error)
                return;
            DataRow dr = mydataSet.Tables[0].NewRow();
            dr["Descript"] = txtbox1.Text;
            dr["Abbr"] = txtbox2.Text;
            dr["SortOrder"] = Convert.ToDecimal(numericOrder.Value);
            mydataSet.Tables[0].Rows.Add(dr);
            dgv.DataSource = mydataSet.Tables[0];
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
