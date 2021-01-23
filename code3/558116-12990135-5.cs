        private void frmFlag_Load(object sender, EventArgs e)
        {
            lvMain.Items.Clear();
            tlstrpcmbCountries.Items.Clear();
            tlstrpcmbCountries.Items.Add("All");
            for (int i = 0; i < countryList.Count; i++)
            {
                tlstrpcmbCountries.Items.Add(countryList[i].Name);
            }
            tlstrpcmbCountries.SelectedIndex = 0;
            tlstrpcmbViews.SelectedIndex = 0;
        }
