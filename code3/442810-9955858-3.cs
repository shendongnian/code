    protected void OnCustomServerValidate(object source, ServerValidateEventArgs e)
    {
        e.IsValid = true;
        // Don't validate anything if `OtherTextBox` is empty
        if (OtherTxtBox.Text.Trim() == String.Empty)
        {                
            return;
        }
    
        // If we got this far then we need to return false if the ControlToValidate has no value
        if (TextBoxToValidate.Text.Trim() == String.Empty)
        {
            e.IsValid = false;
        }            
    }
