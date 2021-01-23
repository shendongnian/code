    //This is the shortest way
    private void txtJustNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true; 
        }
    }
   
