    // On Load...
    city_IDComboBox.DataSource = context.Cities.Local.ToBindingList();
    city_IDComboBox.DisplayMember = "Name";
    city_IDComboBox.ValueMember = "ID";
    
    // Checking value of selection, acting on it
    private void city_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
       var currentCounty = county_IDComboBox.SelectedItem as County;
       var currentCity = city_IDComboBox.SelectedItem as City;
       if (currentCity != null)
       {
          if (currentCounty != null)
          {
             if (currentCity.County_ID == currentCounty.ID)
                return;
          }
          county_IDComboBox.SelectedValue = currentCity.County_ID;
       }
       else
       {
          county_IDComboBox.SelectedItem = null;
       }
    }
