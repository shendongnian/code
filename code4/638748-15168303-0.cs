    void UpdateColorLabel(int cursorX, int cursorY)
    {
        if (image == null)
        {
            lblColorValue.Text = nullText;
        }
        else
        {
            var imageCursorLocation = new Point(scbHorizontal.Value + cursorX, scbVertical.Value + cursorY);
            var px = new Bitmap(image).GetPixel(imageCursorLocation.X, imageCursorLocation.Y);
            lblColorValue.Text = String.Format("R = {0}, G = {1}, B = {2}", px.R, px.G, px.B);
        }            
    }
