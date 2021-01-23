        public void FlyttaMot(int x, int y, float speed)
        {
            float tx = x - pt.X;
            float ty = y - pt.Y;
            float length = Math.Sqrt(tx*tx + ty*ty);
            if (length > speed)
            {
                // move towards the goal
                pt.X = (int)(pt.X + speed* tx/length);
                pt.Y = (int)(pt.Y + speed* ty/length);
            }
            else
            {
                // already there
                pt.X = x;
                pt.Y = y;
            }
        }
