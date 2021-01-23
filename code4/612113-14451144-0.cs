    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class SizeableTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            // Intercept WM_NCHITTEST
            if (m.Msg == 0x84 && this.Multiline) {
                // Find out where the cursor is located
                var pos = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                // Return HTBOTTOMRIGHT if in the lower-right corner
                if (pos.X >= this.Width - 12 && pos.Y >= this.Height - 12) m.Result = (IntPtr)17;
            }
        }
    }
