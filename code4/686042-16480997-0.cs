        bool CustomCursorShown;
        private void button1_MouseUp(object sender, MouseEventArgs e) {
            if (button1.DisplayRectangle.Contains(e.Location)) {
                this.BeginInvoke(new Action(() => {
                    CustomCursorShown = true;
                    button1.Cursor = Cursors.Help;   // Change this to the cursor you want
                    button1.Capture = true;
                }));
            }
        }
        private void button1_MouseDown(object sender, MouseEventArgs e) {
            if (CustomCursorShown) {
                var pos = this.PointToClient(button1.PointToScreen(e.Location));
                var ctl = this.GetChildAtPoint(pos);
                if (ctl != null && e.Button == MouseButtons.Left) {
                    // You may want to alter this if a special action is required
                    // I'm just synthesizing a MouseDown event here...
                    pos = ctl.PointToClient(button1.PointToScreen(e.Location));
                    var lp = new IntPtr(pos.X + pos.Y << 16);
                    // NOTE: taking a shortcut on wparam here...
                    PostMessage(ctl.Handle, 0x201, (IntPtr)1, lp);
                }                 
            }
            button1.Capture = false;
        }
        private void button1_MouseCaptureChanged(object sender, EventArgs e) {
            if (!button1.Capture) {
                CustomCursorShown = false;
                button1.Cursor = Cursors.Default;
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr PostMessage(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp);
