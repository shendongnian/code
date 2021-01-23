    delegate void SetTextCallback(TextBox textBox, string text);
    private void SetText(TextBox textBox, string text)
    {
        if (textBox.InvokeRequired)
        {
            SetTextCallback d = new SetTextCallback(SetText);
            this.Invoke(d, new object[] {textBox, text});
        }
        else
        {
            textBox.Text = text;
        }
    }
