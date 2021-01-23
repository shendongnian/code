        public bool KeepMoving = false;
        private Point offset;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            KeepMoving = true;
            offset = new Point(e.X, e.Y);
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            KeepMoving = false;
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (KeepMoving)
            {
                Left += e.X - offset.X;
                Top += e.Y - offset.Y;
            }
        }
