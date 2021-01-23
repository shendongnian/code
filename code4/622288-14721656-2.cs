    using (Bitmap canvas = new Bitmap((int)width + DOOR_SCHEDULE_WIDTH_ADD,(int)height + DOOR_SCHEDULE_HEIGHT_ADD))
    {
        using( Graphics dc = Graphics.FromImage(canvas))
        {
             dc.DrawEllipse(Pens.Red, 10, 10, 50, 50);
             pictureBox1.Image = (Bitmap)canvas.Clone(); //The PictureBox is just an object to accept the newly created bitmap.
        }
    }
