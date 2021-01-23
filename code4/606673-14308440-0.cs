    var dict = new Dictionary<int, PointPairList>();
    for (int i = 2; i < k; i++)
    {
        if ((tabl1[i].y != null) && (tabl[i].x != null))
        {
            double[] y2 = { 0, tabl1[i].y };
            double[] x2 = { tabl[i].x, 0 };
            dict.Add(i, new PointPairList(x2, y2));
        }
    }
