    public class MovablePictureBox : PictureBox
    {
        private int x;
        private int y;
    
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
    
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
    
            if (e.Button == MouseButtons.Left)
            {
                Left += (e.X - x);
                Top += (e.Y - y);
            }
        }
    }
