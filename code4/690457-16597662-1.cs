    /// <summary>
    /// Converts a given angle into a Vector2.
    /// </summary>
    /// <param name="angle">The angle (in radians).</param>
    /// <param name="normalize">True to normalize the resultant vector, otherwise false.</param>
    /// <returns>A vector representing the specified angle.</returns>
    public static Vector2 Vector2FromAngle(double angle, bool normalize = true)
    {
        Vector2 vector = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        if (vector != Vector2.Zero && normalize)
            vector.Normalize();
        return vector;
    }
