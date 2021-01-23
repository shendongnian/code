    private bool Validate(string text)
    {
        if (!IsDigitsOnly(text)) {
            MessageBox.Show("digits only");            
            return false;
        }
    }
    protected Boolean noLetters() {
        
        if (!Validate(ReadySecTxtBox.Text))
        {
            ReadySecTxtBox.Focus();
            return false;
        }
        if (!Validate(RoundSecTxtBox.Text))
        {
            RoundSecTxtBox.Focus();
            return false;
        }
 
        //...
        else return true;
    }
