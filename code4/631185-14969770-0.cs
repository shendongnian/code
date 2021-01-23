    private void S5233_Checked(object sender, RoutedEventArgs e)
    {
        foreach (var c in Accessories.Children.OfType<CheckBox>())
        {
            if (c.BindingGroup.Name == "523S")
            {
                c.IsEnabled = true;
            }
        }
    }
