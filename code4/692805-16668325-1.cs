        private float angle = 0.0f;
        Image image;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) angle+=1;
            else if (e.KeyCode == Keys.Left) angle-=1;
            int a = ballPB.Location.X;
            int b = ballPB.Location.Y;
            if (e.KeyCode == Keys.Right) a += 5;
            else if (e.KeyCode == Keys.Left) a -= 5;
            ballPB.Location = new Point(a, b);
            RotateImage(arrowPB, image, angle);
        }
        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            //Store our old image so we can delete it
            Image oldImage = pb.Image;
            pb.Image = RotateImage(img, angle);
            if (oldImage != null)
                oldImage.Dispose();
        }
        public static Bitmap RotateImage(Image image, float angle)
        {
            return RotateImageFinal(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }
        public static Bitmap RotateImageFinal(Image image, PointF offset, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);
            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);
            //rotate the image
            g.RotateTransform(angle);
            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);
            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {   //Just to store the address of the 'arrow' image.
            string path = Directory.GetCurrentDirectory();
            image = new Bitmap(path + "\\img\\arrow.png");
        }
