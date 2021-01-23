        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                using (Graphics graphics = CreateGraphics())
                using (SolidBrush brush = new SolidBrush(ForeColor))
                {
                    StringFormat format = new StringFormat(
                           StringFormatFlags.DirectionVertical);
                    SizeF textSize = graphics.MeasureString(Text, Font);
                    graphics.DrawString(
                         Text, Font, brush, 
                         (Width / 2 - textSize.Height / 2),
                         (Height / 2 - textSize.Width / 2),
                         format);
                }
            }
        }
