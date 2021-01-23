        if (String.IsNullOrEmpty(txttea.Text) || String.IsNullOrEmpty(txtcoffee.Text)) 
        {
            MessageBox.Show("select a item");
            txttea.Focus();
        }
        int ina= int.Parse(txttea.Text); // See comment below about TryParse
        int inb= int.Parse(txtcoffee.Text);
        int inc = 0, ind = 0;
       
