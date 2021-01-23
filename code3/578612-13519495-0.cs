    private void ValidateTextBox(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox.Text == "") {
            errorProvider1.SetError(textBox, (string)textBox.Tag);
        } else {
            errorProvider1.SetError(textBox, null);
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        // You can do this in the designer as well
        txtName.Tag = "Please enter a customer name";
        txtAddress.Tag = "Please enter a customer address";
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        ValidateTextBox(txtName, EventArgs.Empty);
        ValidateTextBox(txtAddress, EventArgs.Empty);
    }
