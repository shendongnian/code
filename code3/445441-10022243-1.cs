    namespace GiftWrapping
    {
        using System.Drawing;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        class Program
        {
            static void Main(string[] args)
            {
                List<Point> test = new List<Point>(
                    new Point[]
                        {
                            new Point(200,200), new Point(300,100), new Point(200,50), new Point(100,100),
                            new Point(200, 100), new Point(300, 200), new Point(250, 100), 
                        });
                foreach (Point point in ConvexHull(test))
                {
                    Console.WriteLine(point);
                }
                Console.ReadKey();
            }
            public static List<Point> ConvexHull(List<Point> points)
            {
                if (points.Count < 3)
                {
                    throw new ArgumentException("At least 3 points reqired", "points");
                }
                List<Point> hull = new List<Point>();
                // get leftmost point
                Point vPointOnHull = points.Where(p => p.X == points.Min(min => min.X)).First();
                Point vEndpoint;
                do
                {
                    hull.Add(vPointOnHull);
                    vEndpoint = points[0];
                    for (int i = 1; i < points.Count; i++)
                    {
                        if ((vPointOnHull == vEndpoint)
                            || (Orientation(vPointOnHull, vEndpoint, points[i]) == -1))
                        {
                            vEndpoint = points[i];
                        }
                    }
                    vPointOnHull = vEndpoint;
                }
                while (vEndpoint != hull[0]);
                return hull;
            }
            private static int Orientation(Point p1, Point p2, Point p)
            {
                // Determinant
                int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
                if (Orin > 0)
                    return -1; //          (* Orientation is to the left-hand side  *)
                if (Orin < 0)
                    return 1; // (* Orientation is to the right-hand side *)
                return 0; //  (* Orientation is neutral aka collinear  *)
            }
        }
    }
