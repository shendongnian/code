    private void cmbTripName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbTripName.SelectedItem != null)
        {
            DataRowView drv = cmbTripName.SelectedItem as DataRowView;
            Debug.WriteLine("Item: " + drv.Row["FleetName"].ToString());
            Debug.WriteLine("Value: " + drv.Row["FleetID"].ToString());
            Debug.WriteLine("Value: " + cmbTripName.SelectedValue.ToString());
        }
    }
    
