    var gf = new GeometryFactory();
    var c1 = new[] { new Coordinate(0, 0), new Coordinate(2, 0),
                     new Coordinate(2, 2), new Coordinate(0, 2),
                     new Coordinate(0, 0) };
    var lr1 = gf.CreateLinearRing(c1);
    var p1 = gf.CreatePolygon(lr1, new ILinearRing[0]);
    var c2 = c1.Select(c => new Coordinate(c.X + 1, c.Y + 1)).ToArray();
    var lr2 = gf.CreateLinearRing(c2);
    var p2 = gf.CreatePolygon(lr2, new ILinearRing[0]);
    var intersects = p1.Intersects(p2);        // true
    var intersection = p1.Intersection(p2);    // another polygon
    var area = intersection.Area;              // 1.0
