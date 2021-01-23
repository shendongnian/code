    private void cboOilVehicle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboVehicle.Text == "White Fusion")
        {
            whiteFusionOil();
        } 
        else
        {
            silverFusionOil();    
        }
    }
