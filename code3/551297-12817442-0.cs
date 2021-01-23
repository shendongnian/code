    public class FacadeControl : Control
    {
		private Pen invalidPen;
		
        public FacadeControl()
        {
			invalidPen = new Pen(Color.Red, 2);
            SetStyle(ControlStyles.ResizeRedraw, true); // make sure the control is redrawn every time it is resized
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // get the graphics object to use to draw
            Graphics g = pe.Graphics;
            g.DrawLine(invalidPen, 0, 0, Width, Height);
            g.DrawLine(invalidPen, 0, Height, Width, 0);
        }
    }
}
