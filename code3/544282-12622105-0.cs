    private static bool Intersects(Envelope e1, Envelope e2)
    {
    	return e1.MinX >= e2.MinX && e1.MaxX <= e2.MaxX && e1.MinY >= e2.MinY && e1.MaxY <= e2.MaxY;
    }
    
    List<Envelope> intersectedTiles = extents.SelectMany(es => es)
    	.Where(e => Intersects(bounds, e))
    	.ToList();
