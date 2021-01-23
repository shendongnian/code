    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Graphics g = e.Graphics;
    
        g.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
    
        // Print text
    
        e.DrawFocusRectangle();
    }
