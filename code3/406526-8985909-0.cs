        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                dragging = true;
                start = e.Location;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (dragging) {
                Debug.WriteLine("mousemove X: " + e.X + " Y: " + e.Y);
                pictureBox1.Location = new Point(pictureBox1.Left + e.Location.X - start.X,
                    pictureBox1.Top + e.Location.Y - start.Y);
            }
        }
