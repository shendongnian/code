    //...
    private static bool checkAX(AABB a, OBB o)
    {
        float TAx    = Math.Abs( Vector2.Dot(T, Ax) );
        float WoOxAx = Math.Abs( Vector2.Dot(Vector2.Multiply(Ox, o.halfWidth), Ax) );
        float HoOyAx = Math.Abs( Vector2.Dot(Vector2.Multiply(Oy, o.halfHeight), Ax) );
        if (TAx > a.halfWidth + WoOxAx + HoOyAx)
            return false;
        else
            return true;
    }
    //...
