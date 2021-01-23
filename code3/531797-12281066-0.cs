    for(i=0;i<5;i++)
    {
        double newTriangleRatio = someFunc();
        Contour<Point> contours = someFunc2();
        Dictionary<Contour<Point>, int> dict = new Dictionary<Contour<Point>, int>();
        dict.Add(contours, (int)newTriangleRatio);
        _CD.ratioContoursCollcProperty.Add(dict);
    }
