    private static uint PackColor(Color c)
    {
        return (uint)(c.R << 24 | c.G << 16 | c.B << 8 | c.A);
    }
    private static Color UnpackColor(uint u)
    {
        return new Color()
        {
            R = (byte)(u >> 24),
            G = (byte)(u >> 16),
            B = (byte)(u >> 8),
            A = (byte)(u & 0xFF)
        };
    }
