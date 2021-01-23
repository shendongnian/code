    double price;
    if(double.TryParse(itemPriceTBox.Text, out price) == false)
    {
        MessageBox.Show("Invalid price");
        return;
    }
