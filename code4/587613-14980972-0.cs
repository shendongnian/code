    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace UAC_Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    
            // Make the button display the UAC shield.
            public static void AddShieldToButton(Button btn)
            {
                const Int32 BCM_SETSHIELD = 0x160C;
    
                // Give the button the flat style and make it display the UAC shield.
                btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
                SendMessage(btn.Handle, BCM_SETSHIELD, 0, 1);
            }
    
            // Return a bitmap containing the UAC shield.
            private static Bitmap shield_bm = null;
            public static Bitmap GetUacShieldImage()
            {
                if (shield_bm != null) return shield_bm;
    
                const int WID = 50;
                const int HGT = 50;
                const int MARGIN = 4;
    
                // Make the button. For some reason, it must
                // have text or the UAC shield won't appear.
                Button btn = new Button();
                btn.Text = " ";
                btn.Size = new Size(WID, HGT);
                AddShieldToButton(btn);
    
                // Draw the button onto a bitmap.
                Bitmap bm = new Bitmap(WID, HGT);
                btn.Refresh();
                btn.DrawToBitmap(bm, new Rectangle(0, 0, WID, HGT));
    
                // Find the part containing the shield.
                int min_x = WID, max_x = 0, min_y = HGT, max_y = 0;
    
                // Fill on the left.
                for (int y = MARGIN; y < HGT - MARGIN; y++)
                {
                    // Get the leftmost pixel's color.
                    Color target_color = bm.GetPixel(MARGIN, y);
    
                    // Fill in with this color as long as we see the target.
                    for (int x = MARGIN; x < WID - MARGIN; x++)
                    {
                        // See if this pixel is part of the shield.
                        if (bm.GetPixel(x, y).Equals(target_color))
                        {
                            // It's not part of the shield.
                            // Clear the pixel.
                            bm.SetPixel(x, y, Color.Transparent);
                        }
                        else
                        {
                            // It's part of the shield.
                            if (min_y > y) min_y = y;
                            if (min_x > x) min_x = x;
                            if (max_y < y) max_y = y;
                            if (max_x < x) max_x = x;
                        }
                    }
                }
    
                // Clip out the shield part.
                int shield_wid = max_x - min_x + 1;
                int shield_hgt = max_y - min_y + 1;
                shield_bm = new Bitmap(shield_wid, shield_hgt);
                Graphics shield_gr = Graphics.FromImage(shield_bm);
                shield_gr.DrawImage(bm, 0, 0,
                    new Rectangle(min_x, min_y, shield_wid, shield_hgt),
                    GraphicsUnit.Pixel);
    
                // Return the shield.
                return shield_bm;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Graphics gfx = Graphics.FromImage(button1.BackgroundImage);
                Bitmap shield = GetUacShieldImage();
                gfx.DrawImage(shield, button1.Width / 2, button1.Height / 2);
            }
        }
    }
