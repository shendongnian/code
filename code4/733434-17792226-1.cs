    for (int i = c; i <= 0; i++)
    {
        if (lstCart.GetSelected(i))
        {
            Form2 fm2 = new Form2();
            fm2.productNameTextBox.Text = myBasket[i].ProductName;
            fm2.quantityTextBox.Text = Convert.ToString(myBasket[i].Quantity);
            fm2.latestPriceTextBox.Text = Convert.ToString(myBasket[i].LatestPrice);
            //here is the news:
            fm2.fm1 = this;
            fm2.ShowDialog();
        }
    }
