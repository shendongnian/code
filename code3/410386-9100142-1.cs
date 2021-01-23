using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsApplication1
{
    public class RoundControl : Control
    {
        private readonly GraphicsPath _path;
        public RoundControl()
        {
            _path = new GraphicsPath();
        }
        protected override void OnResize(EventArgs e)
        {
            _path.Reset();
            _path.AddEllipse(ClientRectangle);
            Invalidate(Region);
            Region = new Region(_path);
            base.OnResize(e);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _path.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(ForeColor, 8))
            {
                e.Graphics.DrawEllipse(borderPen, ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
   
