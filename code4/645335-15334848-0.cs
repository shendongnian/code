    internal sealed class Box : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(Point.Empty, new Size(Width - 1, Height - 1)));
        }
    
        protected override void OnClick(EventArgs e)
        {
            MessageBox.Show("You Clicked The Box!");
        }
    }
