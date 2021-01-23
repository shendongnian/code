    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Graphics g = e.Graphics;
    
        g.FillRectangle(new SolidBrush(Color.Blue), e.Bounds);
    
        g.DrawString(listBox.Items[e.Index].ToString(), 
            e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
    
        e.DrawFocusRectangle();
    }
