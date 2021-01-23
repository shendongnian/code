     public class ImageButton : Control
    {
        public Image backgroundImage;
        public Image BackgroundImage
        {
            get
            {
                return backgroundImage;
            }
            set
            {
                backgroundImage = value;
                Refresh();
            }
        }
        public ImageButton()
        {
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if(BackgroundImage != null)
                e.Graphics.DrawImage(BackgroundImage, 0, 0, Width, Height);
            base.OnPaint(e);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
    }
