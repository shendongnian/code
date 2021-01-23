    Bitmap bmp;
    bool isDrawing;
    Point previous;
    void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        isDrawing = true;
        previous = e.Location;
    }
    void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        isDrawing = false;
    }
    void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDrawing)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                double wf = (double)bmp.Width / (double)pictureBox1.Width;
                double hf = (double)bmp.Height / (double)pictureBox1.Height;
                g.ScaleTransform((float)wf, (float)hf);
                g.DrawLine(Pens.Black, e.Location, previous);
            }
            pictureBox1.Refresh();
            previous = e.Location;
        }
    }
