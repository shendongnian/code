    private void EnterKey(object o, KeyPressEventArgs e)
    {
            if(e.KeyChar == (char)Keys.Enter)
            { 
                if(!int.TryParse(orderID.Text, out newCurrentID))
                   MessageBox.Show("Not a number");
                e.Handled = true;
            }
     }
