        Image picImage = null;  // to store original image     
        
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = picImage;   // rest original image
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            picImage = pictureBox1.Image;   // remember the original image
            pictureBox1.Image = null;   // change the current image
        }
