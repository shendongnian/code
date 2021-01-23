    private void inputTextBox_Leave(object sender, EventArgs e)
    {
        if (inputTextBox.Text != string.Empty)
        {
            string input = inputTextBox.Text;
            inputTextBox.Text = input.First().ToString(CultureInfo.InvariantCulture).ToUpper() +
                                string.Join(string.Empty, input.Skip(1));
        }
    }
