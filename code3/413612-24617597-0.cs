    public class TextToolStripSeparator : ToolStripMenuItem
    {
        public override bool CanSelect { get { return DesignMode; } }
        public override bool HasDropDownItems { get { return false; } }
    }
    public class ContextMenuStripEx : ContextMenuStrip
    {
        public ContextMenuStripEx()
        {
            this.Renderer = new ToolStripRendererEx();
        }
        private class ToolStripRendererEx : ToolStripProfessionalRenderer
        {
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                const TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                ToolStripItem item = e.Item;
                if (item is TextToolStripSeparator)
                {
                    int textWidth = TextRenderer.MeasureText(item.Text, item.Font).Width;
                    Rectangle rect = e.TextRectangle;
                    rect.Width = e.ToolStrip.Width - rect.Left;
                    TextRenderer.DrawText(e.Graphics, item.Text, item.Font, rect, Color.DimGray, flags);
                    int y = rect.Y + rect.Height / 2;
                    int margin = (rect.Width - textWidth) / 2;
                    e.Graphics.DrawLine(Pens.DarkGray, rect.X, y, rect.X + margin, y);
                    e.Graphics.DrawLine(Pens.DarkGray, rect.Right - margin, y, rect.Right, y);
                }
                else
                {
                    base.OnRenderItemText(e);
                }
            }
             
        }
    }
