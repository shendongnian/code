    public class CustomPanel : Panel
    {
        int x, y;
        public CustomPanel()
        {
            DoubleBuffered = true;
        }
        float scale;
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            scale = (float)BackgroundImage.Width / BackgroundImage.Height;
            base.OnBackgroundImageChanged(e);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if(BackgroundImage == null) base.OnPaintBackground(e);                        
            else {
             e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
             e.Graphics.DrawImage(BackgroundImage, new Rectangle(0, 0, x,y));
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (scale > (float)Width / Height)
            {
                x = Width;
                y = (int)(Width / scale);
            }
            else
            {
                y = Height;
                x = (int)(Height * scale);
            }
            base.OnSizeChanged(e);
        }
    }
