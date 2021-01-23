    private void ProductsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Product product = productsComboBox.SelectedItem as Product;
        qtyTextBox.Text = product.Quantity.ToString();
        // I use NumericUpDown control to input numbers
        // Minimum is set to 1
        qtyToSellNumericUpDown.Maximum = product.Quantity;
    }
