    private ClipperPolygons graphicsPathToPolygons(GraphicsPath gp)
    {
        ClipperPolygons polyList = new ClipperPolygons();
        ClipperPolygon poly = null;
    
        for (int i = 0; i < gp.PointCount; i++)
        {
            PointF p = gp.PathPoints[i];
            byte pType = gp.PathTypes[i];
    
            if (pType == 0)
            {
                if (poly != null)
                    polyList.Add(poly);
                poly = new ClipperPolygon();
            }
    
            IntPoint ip = new IntPoint();
            ip.X = (int)(p.X * pointScale);
            ip.Y = (int)(p.Y * pointScale);
            poly.Add(ip);
        }
        if (poly != null)
            polyList.Add(poly);
    
        return polyList;
    }
