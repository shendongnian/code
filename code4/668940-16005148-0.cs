     private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (a == 1)
            {
                pictureBox1.Image = pictureBox2.Image;
                a = 0;
            }
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            a = 1;
        }
