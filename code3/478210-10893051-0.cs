    private delegate void MultiThreadSetTextDelegate(TextBox TxtBox, string Text);
    
    public static void MultiThreadSetText(TextBox TxtBox, string Text)
    {
    
            if (TxtBox.InvokeRequired)
            {
                TxtBox.Invoke(new MultiThreadSetTextDelegate(MultiThreadSetText), TxtBox, Text);
            }
            else
            {
                TxtBox.Text = Text;
                TxtBox.Refresh();
            }
    } 
