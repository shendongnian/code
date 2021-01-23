    private void inputTextBox_Validating(object sender, CancelEventArgs e)
    {
        if (inputTextBox.Text == string.Empty)
        {
            statusLabel.Text = "The given input is not valid.";
            e.Cancel = true;
        }
    }
