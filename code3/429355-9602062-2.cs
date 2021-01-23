    protected void myTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs)
    {
        e.Handled = !IsValidCharacter(e.KeyChar);
    }
    
    private bool IsValidCharacter(char c)
    {
        bool isValid = true;
    
        // put your logic here to define which characters are valid
        return isValid;
    }
