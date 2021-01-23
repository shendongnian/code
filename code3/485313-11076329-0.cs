        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove -= OnMouseMove;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pictureBox1.MouseMove += OnMouseMove;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(e.Location);
        }
