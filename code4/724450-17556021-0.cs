    public static void draw(KeyValuePair<int, List<int>> place, Dictionary<int, List<int>> map)
    {
        // Create pen.
        Pen blackPen = new Pen(Color.Black, 3);
        // Create coordinates of points that define line.
        int x1 = place.Value[1];   //topleft to topright
        int y1 = place.Value[3];
        int x2 = place.Value[0];
        int y2 = place.Value[3];
        int x3 = place.Value[0];   //topright to bottomright
        int y3 = place.Value[3];
        int x4 = place.Value[0];
        int y4 = place.Value[2];
        int x5 = place.Value[0];   //bottomright to bottomleft
        int y5 = place.Value[2];
        int x6 = place.Value[1];
        int y6 = place.Value[2];
        int x7 = place.Value[1];   //bottomleft to topleft
        int y7 = place.Value[2];
        int x8 = place.Value[1];
        int y8 = place.Value[3];
        // Draw line to screen.
        using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
        {
            g.DrawLine(blackPen, x1, y1, x2, y2);
            g.DrawLine(blackPen, x3, y3, x4, y4);
            g.DrawLine(blackPen, x5, y5, x6, y6);
            g.DrawLine(blackPen, x7, y7, x8, y8);
        }
        pictureBox1.Invalidate();
    }
