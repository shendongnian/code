    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Drawing;
    
    namespace ColorUnderCursor
    {
        class CursorColor
        {
            [DllImport("gdi32")]
            public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool GetCursorPos(out POINT pt);
    
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
    
            /// <summary> 
            /// Gets the System.Drawing.Color from under the mouse cursor. 
            /// </summary> 
            /// <returns>The color value.</returns> 
            public static Color Get()
            {
                IntPtr dc = GetWindowDC(IntPtr.Zero);
    
                POINT p;
                GetCursorPos(out p);
    
                long color = GetPixel(dc, p.X, p.Y);
                Color cc = Color.FromArgb((int)color);
                return Color.FromArgb(cc.B, cc.G, cc.R);
            }
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            } 
        }
    }
