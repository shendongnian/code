    foreach (PathGeometry pg1 in firstList)
        foreach (PathGeometry pg2 in secondList)
        {
            var s1 = ConvertGeometryToString(pg);
            var s2 = ConvertGeometryToString(pg2);
    
            // Ideally you probably wouldn't want this until you have your 
            // full PathGeometry string built, but I'm not sure what you're doing
            // with the object so left it in anyways
            PathGeometry intergeo = Geometry.Parse(s1 + s2);
        }
    }
    
    
    string ConvertGeometryToString(PathGeometry pg)
    {
        StringBuilder sb = new StringBuilder();
    
        foreach(var figure in pg.PathFigures)
        {
            sb.Append("M " + figure.StartPoint);
    
            foreach(var seg in figure.Segments)
            {
                if (seg is LineSegment)
                    sb.Append(" L " + ((LineSegment)seg).Point);
    
                else if (seg is ArcSegment)
                ... etc
    
            }
    
            if (figure.IsClosed)
                sb.Append(" Z");
        }
    
        return sb.ToString();
    }
