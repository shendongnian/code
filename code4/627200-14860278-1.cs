    Bitmap bitmapPicturebox1;
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.ImageLocation = @"C:\Wallpaper.jpg";
    }
    private void btnLeft_Click(object sender, EventArgs e)
    {
        bitmapPicturebox1 = new Bitmap(pictureBox1.Image);
        bitmapPicturebox1.RotateFlip(RotateFlipType.Rotate90FlipNone);
        pictureBox1.Image = bitmapPicturebox1;
    }  
    private void btnRight_Click(object sender, EventArgs e)
    {
        bitmapPicturebox1 = new Bitmap(pictureBox1.Image);
        bitmapPicturebox1.RotateFlip(RotateFlipType.Rotate270FlipNone);
        pictureBox1.Image = bitmapPicturebox1;
    }
