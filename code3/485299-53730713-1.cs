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
        // (new[] { pt1, pt2, pt3 }).Distinct(new PointComparer()).Count() == 0
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Debug.LogWarning($"The given points must form a triangle. {{{pt1}, {pt2}, {pt3}}}");
            yield break;
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
