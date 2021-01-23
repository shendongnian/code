    protected void country_selected(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
                RadComboBox combo = (RadComboBox)sender;
                GridEditableItem edit = (sender as RadComboBox).NamingContainer as GridEditableItem;
                RadComboBox combos = (RadComboBox)edit.FindControl("dropdwnState");
                LoadStates(combos, combo.SelectedValue);
        }
     protected void LoadStates(RadComboBox combo,string countryId)
        {
            //your defn goes here
        }
