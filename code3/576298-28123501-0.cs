    /// <summary>
    /// AngleBetween - the angle between 2 vectors
    /// </summary>
    /// <returns>
    /// Returns the the angle in degrees between vector1 and vector2
    /// </returns>
    /// <param name="vector1"> The first Vector </param>
    /// <param name="vector2"> The second Vector </param>
    public static double AngleBetween(Vector vector1, Vector vector2)
    {
        double sin = vector1._x * vector2._y - vector2._x * vector1._y;  
        double cos = vector1._x * vector2._x + vector1._y * vector2._y;
        return Math.Atan2(sin, cos) * (180 / Math.PI);
    }
