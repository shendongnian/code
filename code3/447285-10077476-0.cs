    if(validationOK == false)
    {
        // Ask retry or cancel to the user
        if(DialogResult.Cancel == MessageBox.Show("Validation Fail", "Validation failed, press retry to do it againg", MessageBoxButtons.RetryCancel))
            this.DialogResult.Cancel; // Set the dialog result on form2. This will close the form.
        // if you have the validation done in a button_click event and that button has its
        // property DialogResult set to something different than DialogResult.None, we need
        // to block the form2 from closing itself.
        // uncomment this code if the above comment is true
        // else
        //    this.DialogResult = DialogResult.None;
    }
