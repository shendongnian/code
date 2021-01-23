    private Bitmap RotateImage(Bitmap bmp, float angle) {
         Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
         using (Graphics g = Graphics.FromImage(rotatedImage)) {
            // Set the rotation point to the center in the matrix
            g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
            // Rotate
            g.RotateTransform(angle);
            // Restore rotation point in the matrix
            g.TranslateTransform(- bmp.Width / 2, - bmp.Height / 2);
            // Draw the image on the bitmap
            g.DrawImage(bmp, new Point(0, 0));
         }
         return rotatedImage;
    }
