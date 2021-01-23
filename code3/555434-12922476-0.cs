    protected void btUpdate_Click(object sender, EventArgs e)
    {
        string tbcodeValue = this.tbcode.Text.Trim().ToUpper();
    
        string[] validCodes = new string[] { "AB12", "DE14", "XW16" };
        if (!validCodes.Contains(tbcodeValue))
        {
            lbmessage.Text = "Invalid Promo code. Please enter again";
        }
        else 
        {
            Order.Shipping.Cost = 0;
            this.lShipping.Text = Order.Shipping.Cost.ToString("c");
            this.lSubtotal.Text = Order.Subtotal.ToString("c");
            this.lTotal.Text = Order.TotalCost.ToString("c");
            Order.PomoCode = tbcodeValue;
            lbmessage.Text = "Promo Code Applied.";
        }
    }
