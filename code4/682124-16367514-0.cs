        private int intCurMouseX, intCurMouseY;
        private void kpcKnight_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                    intCurMouseX = e.X;
                    intCurMouseY = e.Y;
            }
        }
        private void kpcKnight_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                kpcKnight.Location = new Point(
                    kpcKnight.Location.X + (e.X - intCurMouseX),
                    kpcKnight.Location.Y + (e.Y - intCurMouseY));
            }
        }
