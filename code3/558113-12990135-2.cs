    private void tlstrpcmbCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListViewItem item in lvMain.SelectedItems)
        {
            item.Selected = false;
        }
        var index = this.tlstrpcmbCountries.SelectedIndex - 1;
        if (index >= 0)
        {                
            var item = this.lvMain.Items[index];
            lvMain.EnsureVisible(index);
            item.Selected = true;
            item.Focused = true;
            lvMain.Select();
        }
    }
    private void lvMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lvMain.SelectedItems.Count > 0)
        {
            var selected = lvMain.SelectedItems[0];
            lblCountryName.Text = selected.SubItems[0].Text;
            lblContinent.Text = selected.SubItems[1].Text;
            lblCapitalCity.Text = selected.SubItems[2].Text;
            lblPopulation.Text = selected.SubItems[3].Text;
            lblCurrencyName.Text = selected.SubItems[4].Text;
        }
    }
