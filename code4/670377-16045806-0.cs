    public delegate void RichTextBoxDelegate(string text);
    
    public void ACText(string s)
    {
       ConsoleText.AppendText(s); 
    }
    
    
    RichTextBoxDelegate deleg = new RichTextBoxDelegate(ACText);
