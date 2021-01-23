        private void DrawParabole(Graphics g, int w)
        {
            for (int x = 0; x < w; x++)
            {
                g.DrawLine(
                    Pens.Black,
                    x,
                    FY(x-1),
                    x,
                    FY(x));
            }
        }
