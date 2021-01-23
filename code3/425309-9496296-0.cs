    public class MyCollection : List<Tuple<Point, Point>>
    {
        public void Add(Point p1, Point p2)
        {
            this.Add(Tuple.Create(p1, p2));
        }
    }
