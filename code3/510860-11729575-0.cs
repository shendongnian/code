    private void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtbox1.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Description is required.");
                return;
            }
            if (txtbox2.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Abbr is required.");
                return;
            }
            DataRow dr = mydataSet.Tables[0].NewRow();
            dr["Descript"] = txtbox1.Text;
            dr["Abbr"] = txtbox2.Text;
            dr["SortOrder"] = Convert.ToDecimal(numericOrder.Value);
            if (SortOrders.Contains((decimal)dr["SortOrder"]))
            {
                MessageBox.Show("Please select another one, this one is already used.");
                return;
            }
            mydataSet.Tables[0].Rows.Add(dr);
            dgv.DataSource = mydataSet.Tables[0];
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
