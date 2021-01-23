    /// <summary>
    /// Rotates one point arount another one
    /// </summary>
    /// <param name="pointToRotate">the point to rotate</param>
    /// <param name="centerPoint">the centre point of rotation</param>
    /// <param name="angleInDegrees">the rotation angle in degrees </param>
    /// <returns>Rotated point</returns>
     private Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
    {
        Point rotatedPoint = new Point();
            
        double angleInRadians = angleInDegrees * (Math.PI / 180);
        double cosTheta = Math.Cos(angleInRadians);
        double sinTheta = Math.Sin(angleInRadians);
        rotatedPoint.X = (int)(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X);
        rotatedPoint.Y = (int)(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y);
        return rotatedPoint;
    }
