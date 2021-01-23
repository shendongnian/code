    public void writeToTextBox(int j, string value, TextBox[,] textBoxes)
    {
        TextBox textBox = textBoxes[1, j];
        if (textBox.InvokeRequired)
        {
            textBox.BeginInvoke(new StringParameterDelegate(writeToTextBox), new object[] { j, value, textBoxes });
            return;
        }
        // Must be on the UI thread if we've got this far
        textBox.Text = value;
    }
