        public struct Vertex
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        private static double CalcDistance(Vertex v1, Vertex v2)
        {
            double dX = (v2.X - v1.X);
            double dY = (v2.Y - v1.Y);
            return Math.Sqrt((dX * dX) + (dY * dY));
        }
        private static Vertex[] SortByAngle(IEnumerable<Vertex> vs, Vertex current, Vertex previous)
        {
            var verticesOnDistance = from vertex in vs
                                     where !vertex.Equals(current)
                                     let distance = CalcDistance(current, vertex)
                                     orderby distance
                                     select vertex;
            double priorAngle = Angle(previous, current);
            var verticeAngles = from vertex in verticesOnDistance.Take(3)
                                let nextAngle = Angle(current, vertex)
                                let angleInBetween = (180.0 - priorAngle) + nextAngle
                                orderby angleInBetween descending
                                select vertex;
            
            return verticeAngles.ToArray();
        }
        private static double Angle(Vertex v1, Vertex v2, double offsetInDegrees = 0.0)
        {
            return (RadianToDegree(Math.Atan2(-v2.Y + v1.Y, -v2.X + v1.X)) + offsetInDegrees);
        }
        public static double RadianToDegree(double radian)
        {
            var degree = radian * (180.0 / Math.PI);
            if (degree < 0)
                degree = 360 + degree;
            return degree;
        }
