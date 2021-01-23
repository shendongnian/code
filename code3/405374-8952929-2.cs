    public void changeDenizColor(Color c)
    {
         Bitmap bitmap = new Bitmap(pictureBox1.Image);
         foreach (Nokta n in deniz)
         {
             n.renk = c;
             bitmap.SetPixel(n.point.X, n.point.Y, c);
             pictureBox1.Image = bitmap;
         }
    }
