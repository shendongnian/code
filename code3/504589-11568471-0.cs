    Your paint method should go something like this:
    int Y = 0;
    foreach(PictureBox pb in MyList)
    {
        if(!pb.Visible)
        {
            e.Graphics.DrawImage(new Point(0,Y), pb.BackgroundImage;
            Y += pb.Height;
        }
    }
