    class LngComparer : IComparer<PointLatLng>
        {
            #region IComparer Members
    
            public int Compare(PointLatLng x, PointLatLng y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("At least one argument is null");
                if (x.Lng == y.Lng)
                {
                    if (x.Lat > y.Lat)
                    {
                        return 1;
                    }
                    else if (x.Lat < y.Lat)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                if (x.Lng < y.Lng) return -1;
                return 1;
            }
    
            #endregion
        }
        class Lng2Comparer : IComparer<PointLatLng>
        {
            #region IComparer Members
    
            public int Compare(PointLatLng x, PointLatLng y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("At least one argument is null");
                if (x.Lng == y.Lng)
                {
                    if (x.Lat > y.Lat)
                    {
                        return 1;
                    }
                    else if (x.Lat > y.Lat)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                if (x.Lng > y.Lng) return -1;
                return 1;
            }
    
            #endregion
        }
