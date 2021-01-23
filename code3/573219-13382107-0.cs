            errorProvider= new  System.Windows.Forms.ErrorProvider();
            errorProvider.BlinkRate = 1000;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
    private void TextValidated(object sender, System.EventArgs e)
        {
           var txtbox = Sender as TextBox;
    
            if(IsTextValid(txt))
            {
                // Clear the error, if any, in the error provider.
                errorProvider.SetError(txtbox, String.Empty);
            }
            else
            {
                // Set the error if the name is not valid.
                errorProvider.SetError(txtbox, "Please fill in the missing billing information.");
            }
        }
