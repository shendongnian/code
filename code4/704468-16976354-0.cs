    public static class PictureBoxExtension
    {
        public static void SetImage(this PictureBox pic, Image image, int repeatX)
        {
            Bitmap bm = new Bitmap(image.Width * repeatX, image.Height);
            Graphics gp = Graphics.FromImage(bm);
            for (int x = 0; x <= bm.Width - image.Width; x += image.Width)
            {
                gp.DrawImage(image, new Point(x, 0));
            }
            pic.Image = bm;
        }
    }
    //Now you can use the extension method SetImage to make the PictureBox display the image x-repeatedly 
    myPictureBox.SetImage(myImage, 3);//repeat 3 images horizontally.
