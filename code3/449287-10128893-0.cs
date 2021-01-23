    public IList<IPoint> Points
    {
        get
        {
            return points.ConvertAll<IPoint>(
                delegate(RandomPoint point)
                {
                    return point;
                });
        }   
    
    }
