    this.SetText("Some Text.");
    
    private void SetText(string text)
    {    
     if (this.myTextBox.InvokeRequired)
     {	
      SetTextCallback d = new SetTextCallback(SetText);
      this.Invoke(d, new object[] { text });
     }
     else
     {
      this.myTextBox.Text = text;
     }
    }
