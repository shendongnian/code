    public delegate void SetButtonTextDelegate(string text);
    public void SetButtonText(String text)
    {
         if(button.InvokeRequired)
         {
             Callback settext = new SetButtonTextDelegate(SetButtonText);
             button.Invoke(settext, text);
         }
         else
         {
             button.Text = text;
         }
    }
