    private void button1_Click(object sender, EventArgs e)
        {
            //here I am calling the graphics object of the Picture Box, this will draw to the picture box
            //But the DrawToBitmap, will not reflect this change, and once the Picturebox needs to be updated, this will disappear.
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawRectangle(Pens.Blue, 10, 10, 20, 20);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rectangle bounds = new Rectangle(Left, Top, Width, Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            //Draws whatever is in the PictureBox to the Forms BackgroundImage
            this.BackgroundImage = bmp;
            //It will not draw the Blue rectangle
        }
