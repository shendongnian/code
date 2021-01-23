     if(string.IsNullOrWhiteSpace(txttea.Text) || 
        string.IsNullOrWhiteSpace(txtcoffee.Text))
              {
                MessageBox.Show("select a item");
                txttea.Focus();
                return;
              }
