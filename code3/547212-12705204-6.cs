    class LayerControl : UserControl
    {
        private Image image;
        private Graphics graphics;
        public LayerControl(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            image = new Bitmap(width, height);
            graphics = Graphics.FromImage(image);
            // Set style for control
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint, true);
        }
        // this function will draw your image
        protected override void OnPaint(PaintEventArgs e)
        {
            var bitMap = new Bitmap(image);
            // by default the background color for bitmap is white
            // you can modify this to follow your image background 
            // or create a new Property so it can dynamically assigned
            bitMap.MakeTransparent(Color.White);
            image = bitMap;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.GammaCorrected;
            float[][] mtxItens = {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}};
            ColorMatrix colorMatrix = new ColorMatrix(mtxItens);
            ImageAttributes imgAtb = new ImageAttributes();
            imgAtb.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            g.DrawImage(image,
                        ClientRectangle,
                        0.0f,
                        0.0f,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel,
                        imgAtb);
        }
        // this function will grab the background image to the control it self
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            if (Parent != null)
            {
                BackColor = Color.Transparent;
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
            else
            {
                g.Clear(Parent.BackColor);
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.Transparent)), this.ClientRectangle);
            }
        }
        // simple drawing circle function
        public void DrawCircles()
        {
            using (Brush b = new SolidBrush(Color.Red))
            {
                using (Pen p = new Pen(Color.Green, 3))
                {
                    this.graphics.DrawEllipse(p, 25, 25, 20, 20);
                }
            }
        }
        // simple drawing rectable function
        public void DrawRectangle()
        {
            using (Brush b = new SolidBrush(Color.Red))
            {
                using (Pen p = new Pen(Color.Red, 3))
                {
                    this.graphics.DrawRectangle(p, 50, 50, 40, 40);
                }
            }
        }
        // Layer control image property
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                // this will make the control to be redrawn
                this.Invalidate();
            }
        }
    }
