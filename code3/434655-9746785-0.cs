    // called from ok button click or similar event
    private void Accept()
    {
       if (!ValidateData())
          return;
       SaveData();
       DialogResult = DialogResult.Ok;
       Dispose();
    }
    private bool ValidateData()
    {
       int val;
       if (string.IsNullOrEmpty(mTextBox.Text))
          return FailValidation("Value can not be empty.", mTextBox);
       if (!int.TryParse(mTextBox.Text, out val))
           return FailValidation("Value was not an integer.", mTextBox);
       return true;
    }
    // do something with the value if you need
    private void SaveData()
    {       
    }
    // post a message to the user, and highlight the problematic control
    // always evaluates to false
    private bool FailValidation(string pMessage, Control pControl)
    {
         if (pControl != null)
         {
            pControl.Focus();
            TextBox textBox = pControl as TextBox;
            if (textBox != null)
               textBox.SelectAll();
         }
         AlertBox(pMessage);
         return false;
    }
    // quick alert message method
    private void AlertBox(string pMessage)
    {
       return MessageBox.Show
       (
          pMessage,          
          Application.ProductName,
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1
       );
    }
