    delegate void SetTextCallback(string text);
    private void SetText(string text)
    {
       if (this.InvokeRequired)
       {
          SetTextCallback d = new SetTextCallback(SetText);
          this.Invoke(d, new object[] { text });
       }
       else
       {
          SetText(text);
       }
       this.textBox1.Text = text;     
    }
