    Int32 h = picture.Height;
    Int32 w = picture.Width;
    if (e.X < w && e.Y < h)
    {
        Int32 R = picture.GetPixel(e.X, e.Y).R;
        Int32 G = picture.GetPixel(e.X, e.Y).G;
        Int32 B = picture.GetPixel(e.X, e.Y).B;
        lbPixelValue.Text = "R:" + R + " G:" + G + " B:" + B;
        lbCoordinates.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
    }
    else
    {
        lbPixelValue.Text = "";
        lbCoordinates.Text = "";
    }
