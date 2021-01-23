    private int firstX, firstY;//store coordinates of first click
    private bool firstClick = true;
    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        if (firstClick)
        {
            firstX = e.X;
            firstY = e.Y;
            firstClick = false;
        }
        else
        {
            Line l = new Line();
            l.LineBres(firstX, firstY, e.X, e.Y, panel1.CreateGraphics());
            firstClick = true;
        }
    }
    public class Line
    {
        private Color grad1 = Color.FromArgb(165, 194, 245);
        public void LineBres(int x0, int y0, int xEnd, int yEnd, Graphics e)
        {
            int dx = xEnd - x0;
            int dy = yEnd = y0;
            int p = 2*dy - dx;
            int twoDy = 2*dy;
            int twoDyMinusDx = 2*(dy - dx);
            int x, y;
            if (x0 > xEnd)
            {
                x = xEnd;
                y = yEnd;
                xEnd = x0;
            }
            else
            {
                x = x0;
                y = y0;
            }
            e.FillRectangle(new SolidBrush(grad1), x, y, 1, 1);
            while (x < xEnd)
            {
                x++;
                if (p < 0)
                    p += twoDy;
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                e.FillRectangle(new SolidBrush(grad1), x, y, 1, 1);
            }
        }
    }
