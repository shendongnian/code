    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        var p = new Pen(Color.Red, 5f);
        var pbox = sender as PictureBox;
        var area = (Bitmap)pbox.Image;
        var g = Graphics.FromImage(area);
        g.DrawEllipse(p, e.X, e.Y, 5, 5);
        pbox.Image = area;
        p.Dispose();
        g.Dispose();
    }
