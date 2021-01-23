        private Font GetScaledFont(Graphics g, Font f, float scale)
        {
            return new Font(f.FontFamily,
                            f.SizeInPoints * scale,
                            f.Style,
                            GraphicsUnit.Point,
                            f.GdiCharSet,
                            f.GdiVerticalFont);
        }
        private Rectangle GetScaledRect(Graphics g, Rectangle r, float scale)
        {
            return new Rectangle((int)Math.Ceiling(r.X * scale),
                                (int)Math.Ceiling(r.Y * scale),
                                (int)Math.Ceiling(r.Width * scale),
                                (int)Math.Ceiling(r.Height * scale));
        }
