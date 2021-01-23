    public void ChangeText(string text)
    {
       if(this.InvokeRequired)
       {
          this.Invoke(new Action(() => ChangeText(text)));
       }
       else
       {
          label.Text = text;  
       }
    }
