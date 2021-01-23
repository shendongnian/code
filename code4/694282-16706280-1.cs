    protected void myTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        e.Handled = !IsValidCharacter(e.KeyChar);
    }
    
    private bool IsValidCharacter(Keys c)
    {
        bool isValid = false;
    
        if (c == Keys.Space)
        {
           isValid = true;
        }   
       return isValid; 
    }
