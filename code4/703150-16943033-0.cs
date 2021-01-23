    public class TestControl : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.Transparent);
        }
    
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(System.Drawing.Color.Transparent);
        }
    }
