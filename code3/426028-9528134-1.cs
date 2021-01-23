    if (k == 14)
    {
        try
        {
    
            curr_x = (pictureBox2.Width / 2) + (int)((engval[13] * (pictureBox2.Width)) / map_width);
            curr_y = (pictureBox2.Height / 2) - (int)((engval[14] * (pictureBox2.Height)) / map_height);
            PointF p1 = new Point(curr_x, curr_y);
            if (_gPath != null && _gPath.PointCount > 0)
                p1 = _gPath.PathPoints[_gPath.PathPoints.Length - 1];
            PointF p2 = new Point(curr_x, curr_y);
            _gPath.AddLine(p1, p2);
            pictureBox2.Invalidate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
