    class CustomBtn : Button
    {
        private bool ShouldDraw = false;
        private LinearGradientBrush myBrush = null;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ShouldDraw = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ShouldDraw = false;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (ShouldDraw)
            {
                if (myBrush == null || (myBrush != null && myBrush.Rectangle != ClientRectangle))
                {
                    myBrush = new LinearGradientBrush( ClientRectangle, Color.Red, Color.AliceBlue, LinearGradientMode.Horizontal );
                }
                pevent.Graphics.FillRectangle(myBrush, ClientRectangle);
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, flags);
            }
        }
    }
