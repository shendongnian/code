    public static void TextBoxRequired_Validating(object sender, CancelEventArgs e, ErrorProvider errorProvider)
    {
        var textbox = (TextBox)sender;
        var valid = !String.IsNullOrWhiteSpace(textbox.Text);
        e.Cancel = !valid;
        errorProvider.SetError(textbox, (valid ? string.Empty : textbox.Tag.ToString()));
    }
