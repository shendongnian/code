        void GenerateTest()
        {
            float x1, y1;
            float x2, y2;
             // fill x1,y1,x2,y2
            var r = new Random();
            Func<float> next = () => (float)r.NextDouble();
            var NotMatchingRect = RectangleF.FromLTRB(x1,y1,x2,y2);
            var Coordinates = Enumerable.Range(0, 1000).Select(i => new PointF(next(), next())).Where(p => !NotMatchingRect.Contains(p)).Distinct().Take(2).ToArray();
            if (Coordinates.Length != 2)
                throw new IndexOutOfRangeException();
        }
