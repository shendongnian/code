    private void myTextBox1_Validating(object sender,System.ComponentModel.CancelEventArgs e)
    {        
       if(!CheckIfTextBoxNumeric(myTextBox1))
       {
           myLabel.Text =  "Has to be numeric";
           e.Cancel = true;
       }
    }
    private void myTextBox1_Validated(object sender,System.EventArgs e)
    {
       myLabel.Text = "Validated first control";          
    }
