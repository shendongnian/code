    public void AppendText(String text) 
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<string>(AppendText), new object[] { text });
            return;
        }
        this.Textbox.Text += text;
    }
