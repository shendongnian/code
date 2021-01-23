    public class CustomBorderPictureBox : PictureBox
    {
        public bool BorderDrawn { get; private set; }
        public void ToggleBorder()
        {
            BorderDrawn = !BorderDrawn;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (BorderDrawn)
                using (var pen = new Pen(Color.Black))
                    pe.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
