    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace GDI_PAINTING_EXAMPLE
    {
        public class PaintingExample : Control
        {
            public Graphics G;
            public Bitmap Frame = new Bitmap(256, 256);
            public Bitmap Buffer = new Bitmap(256, 256);
            public PaintingExample()
            {
                // Create a new Graphics instance.
                G = Graphics.FromImage(Buffer);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                // Clears Buffer To White
                G.Clear(Color.White);
                //
                // Do Your Painting Routine
                //
                //
                // End Your Painting Routine
                //
                // Set Frame to draw as Buffer
                Frame = Buffer;
                // Draw Frame with Paint Event Graphics as one image.
                e.Graphics.DrawImage(Frame, new Point(0, 0));
            }
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
            }
        }
    }
