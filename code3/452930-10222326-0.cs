    using (Bitmap myBitmap = new Bitmap(a, b))
    using (Graphics g = Graphics.FromImage(myBitmap)) {
        for (int x = 0; x <= e - 1; x++) {
            for (int y = 0; y <= f - 1; y++) {
                g.DrawRectangle(Pens.LightBlue, g, h, i);
            }
        }
    
        ScorePictureBox.Image = myBitmap;
    }
