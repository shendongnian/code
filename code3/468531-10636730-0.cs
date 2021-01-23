     private void button1_Click(object sender, EventArgs e)
        {
            //The image we will be drawing on then passing to picturebox
            Bitmap bmp=new Bitmap(pictureBox1.Width,pictureBox1.Height);
            using (Graphics g=Graphics.FromImage(bmp))
            {
                using (Bitmap b = new Bitmap(this.Width, this.Height))
                {
                    //captures the Form screenschot, and saves it into Bitmap b
                    this.DrawToBitmap(b, new Rectangle(0, 0, this.Width, this.Height));
                    
                    //this draws the image from Bitmap b starting at the specified location to Bitmap bmp 
                    g.DrawImageUnscaled(b, -100, 0);
                }
            }
            //this assigns pictureBox1 the bmp Bitmap.
            pictureBox1.Image = bmp;
        }
