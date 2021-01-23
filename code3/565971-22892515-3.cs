    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    using System.IO;
    namespace FallingFlowers // Falling Flowers is the name of my project
    {
        public class demo
        {
            public static void relocate(Form fo, int ox, int oy)
            {
                List<Control> list = new List<Control>();
                list = IdentifyControl.findControls(fo);
                for (int i = 0; i < list.Count; i++)
                    reposition(list[i], ox, oy);
            }
            public static void reposition(Control c, int ox, int oy)
            {
                int x, y;
                x = ((c.Location.X * Screen.PrimaryScreen.Bounds.Width) / ox);
                y = ((c.Location.Y * Screen.PrimaryScreen.Bounds.Height) / oy);
                c.Location = new Point(x, y);
                x = ((c.Width * Screen.PrimaryScreen.Bounds.Width) / ox);
                y = ((c.Height * Screen.PrimaryScreen.Bounds.Height) / oy);
                c.Width = x;
                c.Height = y;
                if (c is Label || c is Button)
                    resizeText(c, ox, oy);
            }
            public static void resizeText(Control l, int ox, int oy)
            {
                float s;
                float txtsize = l.Font.Size;
                s = ((txtsize * Screen.PrimaryScreen.Bounds.Width) / ox)+1;
                l.Font = new Font(l.Font.Name, s,l.Font.Style);
            }
            public static void repositionForm(Form f, int ox, int oy)
            {
                int x, y;
                x = (f.Location.X * Screen.PrimaryScreen.Bounds.Width) / ox;
                y = (f.Location.Y * Screen.PrimaryScreen.Bounds.Width) / oy;
                f.Location = new Point(x, y);
            }
        }
    }
