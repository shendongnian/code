    private void pictureB_MouseDown(object sender, MouseEventArgs e)
        {
            WorkAble = true;
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
        }
    
            private void pictureBox_MouseUp(object sender, MouseEventArgs e)
            {
                mouseMove = false;
                lastPointX = e.X;
                lastPointY = e.Y;
            }
    
    
    private void pictureB_MouseMove(object sender, MouseEventArgs e)
    {
        if (WorkAble)
        {
            recLoc.X -= (lastPoint.X - e.X);
            recLoc.Y -= (lastPoint.X - e.X);
            pictureB.Refresh();
            choosingPoint = e.Location;
        }
    }
