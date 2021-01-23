    private bool Validate(ref TextBox txt)
    {
        if (!IsDigitsOnly(txt.Text)) {
            MessageBox.Show("digits only");
            txt.Focus();
            return false;
        }
    }
    protected Boolean noLetters() {
        
        if (!Validate(ref ReadySecTxtBox))
            return false;
        if (!Validate(ref RoundSecTxtBox))
            return false;
         
        //...
        else return true;
    }
