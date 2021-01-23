    public void writeToTextBox(int j, string value, Form form)
    {
        if (form.InvokeRequired)
        {
            form.BeginInvoke(new StringParameterDelegate(writeToTextBox), new object[] { j, value });
            return;
        }
        // Must be on the UI thread if we've got this far
        form.textbox[1, j].Text = value;
    }
