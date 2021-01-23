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
