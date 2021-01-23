    comboBoxPlatypusId.SelectedIndex = comboBoxPlatypusId.Items.IndexOf(DuckbillVals[Duckbill_PlatypusID]);
    comboBoxPlatypusId.Tag = comboBoxPlatypusId.SelectedIndex;
    ...
    private void comboBoxFunnyMammals_SelectedValueChanged(object sender, EventArgs e) {
    	var cb = sender as ComboBox;
    	if (cb != null)
    	{
    		int validSelection = Convert.ToInt32(cb.Tag);
    		if (cb.SelectedIndex != validSelection) {
    			cb.SelectedIndex = validSelection;
    		}
    	}
    }
