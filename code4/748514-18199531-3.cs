    public bool DoesIntersect(Rect topRect, Rect bottomRect, Rect ballRect)
    {
        topRect.Intersect(ballRect);
        bottomRect.Intersect(ballRect);
        if (topRect.IsEmpty && bottomRect.IsEmpty)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
