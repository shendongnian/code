    delegate void SetTextCallback(string text);
    
    private void SetText(string text)
    {
        if (textBox.InvokeRequired)
        {    
            SetTextCallback d = new SetTextCallback(SetText);
            this.Invoke(d, new object[] { text });
        }
        else
        {
            textBox.Text = text;
        }
    }
