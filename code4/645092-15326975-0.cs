    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        var originalText = myMaskedTextBox.Text;
        var parsedText = Regex.Replace(myMaskedTextBox.Text, "[^a-z_A-Z]", "");
        if (originalText == parsedText)
            labelInfo.Text = "Valid string";
        else
        {
            myMaskedTextBox.Text = parsedText;
            labelInfo.Text = "Only alpha-numeric characters please";    
        }
    }
