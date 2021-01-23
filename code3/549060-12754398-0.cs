    int propertyPrice;
    if (Int32.TryParse(propertyPriceTextBox.Text, out propertyPrice)
    {
        // use propertyPrice
    }
    else
    {
        MessageBox.Show("Property Price must be a whole number.");
    }
