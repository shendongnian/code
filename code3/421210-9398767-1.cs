        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Cursor.Position.X - Location.X) >= 904 && (Cursor.Position.X - Location.X) <= 963 && (Cursor.Position.Y - Location.Y) >= 145 && (Cursor.Position.Y - Location.Y) <= 167)
            {
                mousestatus = 1;
                mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                timer4.Start();
            }
        }
