        Point mousePos;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            mousePos = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int dx = e.X - mousePos.X;
                int dy = e.Y - mousePos.Y;
                pictureBox1.Location = new Point(pictureBox1.Left + dx, pictureBox1.Top + dy);
            }
        }
