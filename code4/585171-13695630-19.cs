    /// <summary>
    /// Converts an angle in decimal degress to radians.
    /// </summary>
    /// <param name="angleInDegrees">The angle in degrees to convert.</param>
    /// <returns>Angle in radians</returns>
    static double DegreesToRadians(double angleInDegrees)
    {
       return angleInDegrees * (Math.PI / 180);
    }
    /// <summary>
    /// Rotates a point around the origin
    /// </summary>
    /// <param name="pointToRotate">The point to rotate.</param>
    /// <param name="angleInDegrees">The rotation angle in degrees.</param>
    /// <returns>Rotated point</returns>
    static Point RotatePoint(Point pointToRotate, double angleInDegrees)
    {
       return RotatePoint(pointToRotate, new Point(0, 0), angleInDegrees);
    }
