    private void btnOK_Click(object sender, EventArgs e) 
    {
        if (string.IsNullOrWhiteSpace(FilePath))
        { 
            //show message box with error
            DialogResult = DialogResult.Cancel;
            return;
        }
         
        // you can assign default dialog result to btnOK in designer
        DialogResult = DialogResult.OK;
    }
    public string FilePath
    {
        get { return txtFilePath.Text; }
    }
