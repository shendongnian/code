    class CutomToolStripMenuRenderer : ToolStripRenderer
    {
        // This type demonstrates a custom renderer. It overrides the // OnRenderMenuItemBackground and OnRenderButtonBackground methods // to customize the backgrounds of MenuStrip items and ToolStrip buttons. class CustomProfessionalRenderer : ToolStripProfessionalRenderer
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(Color.Green))
                {
                    e.Graphics.FillEllipse(b, e.Item.ContentRectangle);
                }
            }
            else
            {
                using (Pen p = new Pen(Color.Gold))
                {
                    e.Graphics.DrawEllipse(p, e.Item.ContentRectangle);
                }
            }
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle r = Rectangle.Inflate(e.Item.ContentRectangle, -2, -2);
            if (e.Item.Selected)
            {
                using (Brush b = new SolidBrush(Color.Orange))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }
            else
            {
                using (Pen p = new Pen(Color.Orchid))
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
    }
