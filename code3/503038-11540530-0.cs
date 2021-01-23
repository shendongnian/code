        private void cboCategories_SelectedValueChanged(object sender, EventArgs e)
    {
        int val = Convert.ToInt32(cboCategories.SelectedValue);
        ModifGrid(val);
    }
    private void ModifGrid(int ModifiedValue)
    {
        if (Convert.ToInt32(productBindingSource.Count)>0)
        {
            ((Product)productBindingSource.Current).CategoryID = ModifiedValue;
        }
    }
