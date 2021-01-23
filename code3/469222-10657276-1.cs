    bool PointInRectangle(Point pt, double North, double East, double South, double West)
    {
        // you may want to check that the point is a valid coordinate
        if (West < East)
        {
            return pt.X < East && pt.X > West && pt.Y < North && pt.Y > South;
        }
        else // it crosses the date line
        {
            return (pt.X < East || pt.X > West) && pt.Y < North && pt.Y > South;
        }
    }
