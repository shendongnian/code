    using(Form2 fm2 = new Form2(this))
    {
        fm2.productNameTextBox.Text = myBasket[i].ProductName;
        fm2.quantityTextBox.Text = Convert.ToString(myBasket[i].Quantity);
        fm2.latestPriceTextBox.Text = Convert.ToString(myBasket[i].LatestPrice);
        if(DialogResult.OK == fm2.ShowDialog(this))
        {
            myBasket[i].ProductName = frm2.productNameTextBox.Text;
            myBasket[i].Quantity = Convert.ToInt32(frm2.quantityTextBox.Text);
            myBasket[i].LatestPrice = Convert.ToDecimal(frm2.latestPriceTextBox.Text);
        }
    }
