    class Foo : Form
    {
        private Bitmap m_background;
        private Bitmap m_backBuffer;
        private Brush m_blackBrush;
        private Pen m_blackPen;
        public Foo()
        {
            m_blackBrush = new SolidBrush(Color.Black);
            m_blackPen = new Pen(Color.Black, 2);
            // redo all of this on Resize as well
            m_backBuffer = new Bitmap(this.Width, this.Height);
            m_background = new Bitmap(this.Width, this.Height);
            using (var g = Graphics.FromImage(m_background))
            {
                // draw in a static background here
               g.DrawRectangle(m_blackBrush, ...);
                // etc.
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
        protected override void  OnPaint(PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(m_backBuffer))
            {
                // use appropriate back color
                // only necessary if the m_background doesn't fill the entire image
                g.Clear(Color.White);
                // draw in the static background
                g.DrawImage(m_background, 0, 0);
                // draw in dynamic items here
                g.DrawLine(m_blackPen, ...);
            }
            e.Graphics.DrawImage(m_backBuffer, 0, 0);         
        } 
    }
