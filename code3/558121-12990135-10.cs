        private void tlstrpcmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var country = countryList.Where(c => c.Name.Equals(tlstrpcmbCountries.SelectedItem.ToString())).Select(s => s).FirstOrDefault();
            
            if (country != null)
            {
                lvMain.Items.Clear();
                ListViewItem item = new ListViewItem(country.Name, country.Flag);
                item.SubItems.Add(country.Continent);
                item.SubItems.Add(country.Capital);
                item.SubItems.Add(country.Population);
                item.SubItems.Add(country.Currency);
                lvMain.Items.Add(item);
                lvMain.EnsureVisible(0);
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
