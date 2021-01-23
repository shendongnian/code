    class Program
    {
        public struct Point
        {
            public static Point Create(int x, int y)
            {
                return new Point() { X = x, Y = y };
            }
            public int X { get; set; }
            public int Y { get; set; }
            public override string ToString()
            {
                return string.Format("({0}|{1})", X, Y);
            }
        }
        static void Main(string[] args)
        {
            //helper to avoid to much keystrokes :)
            var f = new Func<int, int, Point>(Point.Create);
            //compose the point array
            //(1|1),(2|1),(4|1),(1|2),(2|3),(3|3),(4|3),(5|8),(9|10)
            var points = new[] { f(1, 1), f(2, 1), f(4, 1), f(1, 2), f(2, 3), f(3, 3), f(4, 3), f(5, 8), f(9, 10) }.OrderBy(p => p.Y);
            //create a 'previous point' array which is a copy of the source array with a item inserted at index 0
            var firstPoint = points.FirstOrDefault();
            var prevPoints = new[] { f(firstPoint.X - 1, firstPoint.Y) }.Union(points);
            //keep track of a counter which will be the second group by key. The counter is raised whenever the previous X was not equal
            //to the current - 1
            int counter = 0;
            //the actual group by query
            var query = from point in points.Select((x, ix) => new { current = x, prev = prevPoints.ElementAt(ix) })                        
                        group point by new { point.current.Y, prev = (point.prev.X == point.current.X - 1 ? counter : ++counter) };
            //method chaining equivalent
            query = points.Select((x, ix) => new { current = x, prev = prevPoints.ElementAt(ix) })
                          .GroupBy(point => new { point.current.Y, prev = (point.prev.X == point.current.X - 1 ? counter : ++counter) });
            //print results
            foreach (var item in query)
                Console.WriteLine(string.Join(", ", item.Select(x=> x.current)));            
            Console.Read();
        }
    }
