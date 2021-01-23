        public void FlyttaMot(int x, int y, float speed)
        {
            float tx = x - pt.X;
            float ty = y - pt.Y;
            float length = Math.Sqrt(tx*tx + ty*ty);
            if (length > 0.000001)
            {
                pt.X = (int)(pt.X + speed* tx/length);
                pt.Y = (int)(pt.Y + speed* ty/length);
            }
        }
