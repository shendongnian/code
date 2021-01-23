    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Drawing;
    
    class CursorHue
        {
            [DllImport("gdi32")]
            public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
    
            public static float GetHue(Point p)
            {           
                long color = GetPixel(dc, p.X, p.Y);
                Color cc = Color.FromArgb((int)color);
                return cc.GetHue();
            }
        }
