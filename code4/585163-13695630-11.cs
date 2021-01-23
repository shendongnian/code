    /// <summary>
    /// Converts an angle in decimal degress to radians.
    /// </summary>
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
      double r = DegreesToRadians(angleInDegrees);
      double ct = Math.Cos(r);
      double st = Math.Sin(r);
      return new Point
      {
         X = (int)(ct * pointToRotate.X - st * pointToRotate.Y),
         Y = (int)(st * pointToRotate.X + ct * pointToRotate.Y)
      };
    }
