    private void lbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(((ListBox)sender).SelectedValue != null)
        {
           var t2 = (from o in db.Orders
                    where o.CustomerID == ((ListBox)sender).SelectedValue.ToString()
                    select o);
           lbxCustCountry.ItemsSource = t2;
           Tab0Total.Text = lbxCustCountry.Items.Count.ToString();
        }
    }
