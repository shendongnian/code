    public class Prog : ProgressBar
    {
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                var flags = TextFormatFlags.VerticalCenter |
                            TextFormatFlags.HorizontalCenter |
                            TextFormatFlags.SingleLine |
                            TextFormatFlags.WordEllipsis;
                TextRenderer.DrawText(CreateGraphics(),
                                      ((float)this.Value/this.Maximum*100) + "%",
                                      Font,
                                      new Rectangle(0, 0, this.Width, this.Height),
                                      Color.Black,
                                      flags);
            }
        }
    }
