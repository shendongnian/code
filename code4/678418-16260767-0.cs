    private void txtrate_TextChanged(object sender, EventArgs e) 
    { 
        int a = Convert.ToInt32(txtqty.Text); 
        int b = Convert.ToInt32(txtrate.Text); 
        if (Int32.TryParse(txtqty.Text, out a) && (Int32.TryParse(txtrate.Text, out b)
        {
            int c = a * b; 
            txttotal.Text = c.ToString();
        }
    }
