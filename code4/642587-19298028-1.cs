    public class PolygonFence
    {
        public List<Point> PointList = new List<Point>();
        public PolygonFence(List<Point> points)
        {
            foreach (Point p in points)
            {
                this.PointList.Add(p);
            }
        }
        public int Count()
        {
            return PointList.Count;
        }
        public bool IsWithinFence(Point p)
        {
            int sides = this.Count();
            int j = sides - 1;
            bool pointStatus = false;
            for (int i = 0; i < sides; i++)
            {
                if (PointList[i].Y < p.Y && PointList[j].Y >= p.Y || PointList[j].Y < p.Y && PointList[i].Y >= p.Y)
                {
                    if (PointList[i].X + (p.Y - PointList[i].Y) / (PointList[j].Y - PointList[i].Y) * (PointList[j].X - PointList[i].X) < p.X)
                    {
                        pointStatus = !pointStatus;
                    }
                }
                j = i;
            }
            return pointStatus;
        }
    }
