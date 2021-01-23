    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Graphics myCustomGraphic = e.Graphics;
        myCustomGraphic.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
        // Print text
        e.DrawFocusRectangle();
    }
