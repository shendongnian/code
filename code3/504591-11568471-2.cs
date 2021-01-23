    int Y = 0;
    foreach(PictureBox pb in MyList)
    {
        if(!pb.Visible)
        {
            e.Graphics.DrawImage(pb.BackgroundImage, new Point(0,Y));
            Y += pb.Height;
        }
    }
