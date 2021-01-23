    protected override void OnPaintBackground(PaintEventArgs e)
    {
        using (var brush = new LinearGradientBrush(ClientRectangle,
               Color.Red, Color.Blue, LinearGradientMode.Vertical)) {
            e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }
    }
