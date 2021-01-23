    public static IEnumerable<T> PointsInTriangle<T>(T pt1, T pt2, T pt3)
       where T : IPoint
    {
        /*
             // https://www.geeksforgeeks.org/check-whether-triangle-valid-not-sides-given/
             a + b > c
             a + c > b
             b + c > a
         */
        float a = Vector2.Distance(new Vector2(pt1.x, pt1.y), new Vector2(pt2.x, pt2.y)),
              b = Vector2.Distance(new Vector2(pt2.x, pt2.y), new Vector2(pt3.x, pt3.y)),
              c = Vector2.Distance(new Vector2(pt3.x, pt3.y), new Vector2(pt1.x, pt1.y));
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Debug.LogWarning($"The given points must form a triangle. {{{pt1}, {pt2}, {pt3}}}");
            yield break;
        }
        if (TriangleArea(pt1, pt2, pt3) <= 1)
        {
            Point center = GetTriangleCenter(pt1, pt2, pt3);
            yield return (T)Activator.CreateInstance(typeof(T), center.x, center.y);
            return;
        }
        T tmp;
        if (pt2.x < pt1.x)
        {
            tmp = pt1;
            pt1 = pt2;
            pt2 = tmp;
        }
        if (pt3.x < pt2.x)
        {
            tmp = pt2;
            pt2 = pt3;
            pt3 = tmp;
            if (pt2.x < pt1.x)
            {
                tmp = pt1;
                pt1 = pt2;
                pt2 = tmp;
            }
        }
        var baseFunc = CreateFunc(pt1, pt3);
        var line1Func = pt1.x == pt2.x ? (x => pt2.y) : CreateFunc(pt1, pt2);
        for (var x = pt1.x; x < pt2.x; ++x)
        {
            int maxY;
            int minY = GetRange(line1Func(x), baseFunc(x), out maxY);
            for (int y = minY; y <= maxY; ++y)
                yield return (T)Activator.CreateInstance(typeof(T), x, y);
        }
        var line2Func = pt2.x == pt3.x ? (x => pt2.y) : CreateFunc(pt2, pt3);
        for (var x = pt2.x; x <= pt3.x; ++x)
        {
            int maxY;
            int minY = GetRange(line2Func(x), baseFunc(x), out maxY);
            for (int y = minY; y <= maxY; ++y)
                yield return (T)Activator.CreateInstance(typeof(T), x, y);
        }
    }
    private static int GetRange(float y1, float y2, out int maxY)
    {
        if (y1 < y2)
        {
            maxY = Mathf.FloorToInt(y2);
            return Mathf.CeilToInt(y1);
        }
        maxY = Mathf.FloorToInt(y1);
        return Mathf.CeilToInt(y2);
    }
    private static Func<int, float> CreateFunc<T>(T pt1, T pt2)
        where T : IPoint
    {
        var y0 = pt1.y;
        if (y0 == pt2.y)
            return x => y0;
        float m = (float)(pt2.y - y0) / (pt2.x - pt1.x);
        return x => m * (x - pt1.x) + y0;
    }
        public static float TriangleArea<T>(T p1, T p2, T p3)
            where T : IPoint
        {
            float a, b, c;
            if (!CheckIfValidTriangle(p1, p2, p3, out a, out b, out c))
                return 0;
            return TriangleArea(a, b, c);
        }
        public static float TriangleArea(float a, float b, float c)
        {
            // Thanks to: http://james-ramsden.com/area-of-a-triangle-in-3d-c-code/
            float s = (a + b + c) / 2.0f;
            return Mathf.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public static Point GetTriangleCenter<T>(T p0, T p1, T p2)
            where T : IPoint
        {
            // Thanks to: https://stackoverflow.com/questions/524755/finding-center-of-2d-triangle
            return new Point(p0.x + p1.x + p2.x / 3, p0.y + p1.y + p2.y / 3);
        }
        public static bool CheckIfValidTriangle<T>(T v1, T v2, T v3, out float a, out float b, out float c)
            where T : IPoint
        {
            a = Vector2.Distance(new Vector2(v1.x, v1.y), new Vector2(v2.x, v2.y));
            b = Vector2.Distance(new Vector2(v2.x, v2.y), new Vector2(v3.x, v3.y));
            c = Vector2.Distance(new Vector2(v3.x, v3.y), new Vector2(v1.x, v1.y));
            if (a + b <= c || a + c <= b || b + c <= a)
                return false;
            return true;
        }
