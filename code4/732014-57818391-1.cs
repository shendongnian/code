    public static class PanelExtension {
    public static void ScrollDown(this Panel p)
    {
       
        using (Control c = new Control() { Parent = p, Height = 1, Top = p.ClientSize.Height + 1 })
        {
            p.ScrollControlIntoView(c);                
        }
    }
    public static void ScrollUp(this Panel p )
    {
       
        using (Control c = new Control() { Parent = p, Height = 1, Top = -1})
        {
            p.ScrollControlIntoView(c);                
        }
    }
    }
        //use the code, suppose you have 2 buttons, up and down to control the scrollbar instead of clicking directly on the scrollbar arrows.
     
            private void buttonUp_Click(object sender, EventArgs e)
    {
  
       yourPanel.ScrollUp();
    }
    private void buttonDown_Click(object sender, EventArgs e)
    {
  
       yourPanel.ScrollDown();
    }
