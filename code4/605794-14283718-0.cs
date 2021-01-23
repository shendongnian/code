    double total = 0; 
    private void btnItem2_Click(object sender, EventArgs e)
        {
    
    
            lblItemPrice.Text = string.Format("£{0:0.00}", btnItem2.Tag);
    
            lstTill.Items.Add(btnItem2.Text + "\t" + (string.Format(btnItem2.Tag.ToString())));
    
            this.lstTill.TopIndex = this.lstTill.Items.Count - 1;
    
            total = total+ Convert.ToDouble(btnItem2.Tag);
            lblTotalPrice.Text = "£ " + Convert.ToString(lblItemPrice);
        }
