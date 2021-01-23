    //This can help you control the scrollbar with scrolling up and down.
    //The position is a little special.
    //Position for scrolling up should be negative.
    //Position for scrolling down should be positive
    public static class PanelExtension {
        public static void ScrollDown(this Panel p, int pos)
        {
            //pos passed in should be positive
            using (Control c = new Control() { Parent = p, Height = 1, Top = p.ClientSize.Height + pos })
            {
                p.ScrollControlIntoView(c);                
            }
        }
        public static void ScrollUp(this Panel p, int pos)
        {
            //pos passed in should be negative
            using (Control c = new Control() { Parent = p, Height = 1, Top = pos})
            {
                p.ScrollControlIntoView(c);                
            }
        }
    }
    //use the code, suppose you have 2 buttons, up and down to control the scrollbar instead of clicking directly on the scrollbar arrows.
    int i = 0;
    private void buttonUp_Click(object sender, EventArgs e)
    {
       if (i >= 0) i = -1;
       yourPanel.ScrollUp(i--);
    }
    private void buttonDown_Click(object sender, EventArgs e)
    {
       if (i < 0) i = 0;
       yourPanel.ScrollDown(i++);
    }
