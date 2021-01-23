    void timer_Tick(object sender, EventArgs e)
    {
        if (pictureBox1.Image != null)
            pictureBox1.Image.Dispose(); // dispose old image (you might consider reusing it rather than making a new one each frame)
        Point test = new Point(0, 0);
        Image img = new Bitmap(400, 400); 
        pictureBox1.Image = img;
        Graphics g = Graphics.FromImage(pictureBox1.Image);
        Matrix mm1 = new Matrix();
        mm1.RotateAt((trackBar1.Value), new Point( 0,0), MatrixOrder.Append); // note that the angle is in degrees, so make sure the trackbar value or input is suitably scaled
        GraphicsPath gp = new GraphicsPath();
        gp.AddPolygon(new Point[] { new Point(0, 0), new Point(imgpic.Width, 0), new Point(0, imgpic.Height) });
        //PointF[] pts = gp.PathPoints; // not needed for this task
        g.DrawPath(Pens.Black, gp); // draw the path with a simple black pen
        g.Transform = mm1; // transform the graphics object so the image is rotated
        g.DrawImage(imgpic, test); // if the image needs to be behind the path, draw it beforehand
        mm1.Dispose();
        gp.Dispose();
        g.Disose(); // prevent possible memory leaks
        pictureBox1.Refresh();
    }
