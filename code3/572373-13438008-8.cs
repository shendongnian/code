    private void panFill_MouseDown(object sender, MouseEventArgs e)
    {
        //Create a bitmap
        bmp = new Bitmap(panFill.ClientSize.Width, _
                         panFill.ClientSize.Height, _
                         Imaging.PixelFormat.Format32bppPArgb);
        panFill.DrawToBitmap(bmp, panFill.ClientRectangle);
        //store origo/start point and mark that we're active
        regStart = e.Location;
        inDrag = true;
    }
    private void panFill_MouseUp(object sender, MouseEventArgs e)
    {
        inDrag = false;
        //we're done, clean up resources if any
        if (bmp != null) {
            bmp.Dispose();
            bmp = null; //use as marker for this check
        }
        //clean up by redrawing panel
        Rectangle r = new Rectangle(regStart, _
                                    new Size(regOld.X - regStart.X + 1, _
                                             regOld.Y - regStart.Y + 1));
        panFill.Invalidate(r, true);
    }
