        private void countryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (citizenViewModelBindingSource.Current != null)
            {
                cityBindingSource.DataSource = GetCities(((Country)countryBindingSource.Current).ID);
                // update the combo box manually
                cmbCity.SelectedValue = ((CitizenViewModel)citizenViewModelBindingSource.Current).CityID;
            }
        }
