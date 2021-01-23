    private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
    ...
    if (e.State == DrawItemState.Selected)
        {
            // Draw a different background color, and don't paint a focus rectangle.
            _textBrush = new SolidBrush(Color.Black);
            g.FillRectangle(Brushes.White, e.Bounds);
        }
        else
        {
            _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
            g.FillRectangle(Brushes.WhiteSmoke, e.Bounds); 
        }
    ...
