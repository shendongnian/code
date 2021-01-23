    private bool ValidateAndFocus(ref TextBox txt)
    {
        if (!IsDigitsOnly(txt.Text)) {
            MessageBox.Show("digits only");            
            txt.Focus();
            return false;
        }
    }
    protected Boolean noLetters() {
        
        if (!ValidateAndFocus(ref ReadySecTxtBox))
            return false;
        if (!ValidateAndFocus(ref RoundSecTxtBox))
            return false;
 
        //...
        else return true;
    }
