     if ((this.tbcode.Text.Trim().ToUpper() != "AB12") && (this.tbcode.Text.Trim().ToUpper() != "DE14") && (this.tbcode.Text.Trim().ToUpper() != "XW16"))
        {
            lbmessage.Text = "Invalid Promo code. Please enter again";
        }
        else if ((this.tbcode.Text.Trim().ToUpper() == "AB12") || (this.tbcode.Text.Trim().ToUpper() == "DE14") || (this.tbcode.Text.Trim().ToUpper() == "XW16"))
        {
            Order.Shipping.Cost = 0;
            this.lShipping.Text = Order.Shipping.Cost.ToString("c");
            this.lSubtotal.Text = Order.Subtotal.ToString("c");
            this.lTotal.Text = Order.TotalCost.ToString("c");
            Order.PomoCode = this.tbcode.Text.Trim().ToUpper();
            lbmessage.Text = "Promo Code Applied.";
        }
        else
        {
            this.lShipping.Text = Order.Shipping.Cost.ToString("c");
            this.lSubtotal.Text = Order.Subtotal.ToString("c");
            this.lTotal.Text = Order.TotalCost.ToString("c");
    
        }
