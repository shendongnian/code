    public void Quantity_TextChanged(object sender, KeyEventArgs e)
    {
          var total = Price.Text * Quantity.Text;  // store the price * the quantity in the total variable
          MessageBox.Show(total);  // show the total in a message box
    }
