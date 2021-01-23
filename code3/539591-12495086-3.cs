    private void cmbTripName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbTripName.SelectedItem != null)
        {
            label1.Text = cmbTripName.SelectedItem.ToString();
            label2.Text = cmbTripName.SelectedValue.ToString();
        }
    }
    
