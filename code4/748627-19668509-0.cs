    using System.Windows.Forms;
    namespace WireWorld
    {
        public class ZoomablePicturebox : PictureBox
        {
            public ZoomablePicturebox()
            {
            }
            protected override void OnPaint(PaintEventArgs pe)
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                pe.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                pe.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                base.OnPaint(pe);
            }
        }
    }
