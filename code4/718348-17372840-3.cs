    double m = 0.5;
    double c = 1.5;
    Func<double, float> f = x => (float)(m*x + c);
    Random rng = new Random();
    PointF p1 = new PointF(-1000, f(-1000));
    PointF p2 = new PointF(1000, f(1000));
    var intersector = new LineIntersectionChecker(p1, p2, 0.1);
    Debug.Assert(intersector.IsOnLine(new PointF(0f, 1.5f)));
    for (int i = 0; i < 1000; ++i)
    {
        float x = rng.Next((int)p1.X+2, (int)p2.X-2);
        PointF p = new PointF(x, f(x));
        Debug.Assert(intersector.IsOnLine(p));
    }
