    Dictionary<Contour<Point>,int> myDict = new Dictionary<Contour<Point>,int>();
    for(i=0;i<5;i++)
    {
     int newTriangleRatio = someFunc();
     Contour<Point> contours = someFunc2();
     myDict.Add(contours,newTriangleRatio);
    }
    _CD.RatioContoursCollcProperty.Add(myDict);
