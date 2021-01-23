    private void btnOK_Click(object sender, EventArgs e)
    {
        bool fieldsFilled = ValidateStrings(folderNameLabel.Text, 
                                            folderTitle.Text, 
                                            folderDescription.Text, 
                                            folderCategory.Text);
        if (fieldsFilled)
            DialogResult = DialogResult.OK;
        else
        {
            // Report errors
        }
    }
    private bool ValidateStrings(params string[] items)
    {
        bool result = true;
        for (int i = 0; i < items.Length && result; i++)
            result &= !String.IsNullOrWhitespace(items[i]);
        return result;
    }
