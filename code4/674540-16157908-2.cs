    private void UpdateLabel(string text)
    {
        if (!this.richTextRxMessage.InvokeRequired)
        {
            this.richTextRxMessage.Text=text;
            
        }
        else
        {
            var s = new UpdateFormText(UpdateLabel);
            Invoke(s, new object[] { text});
        }
    }
