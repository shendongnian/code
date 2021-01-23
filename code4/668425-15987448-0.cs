    /// <summary>
    /// Calculates ball bouncing.
    /// </summary>
    /// <param name="x">X position (0 .. 360)</param>
    /// <returns>Returns y position (0 .. 1)</returns>
    private double Position(double x)
    {
        x *= Math.PI / 180;
        return Math.Abs(Math.Cos(x)); // Always positive
    }
