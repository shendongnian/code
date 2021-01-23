    protected void myTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs)
    {
        e.Handled = !IsValidCharacter(e.KeyChar);
    }
    
    private bool IsValidCharacter(char c)
    {
        bool isValid = false;
    
       if (c==(char)8)
    {
        isValid = true;
    }   
     return isValid; 
    }
