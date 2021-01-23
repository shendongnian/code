    public Color Lerp(Color c1, Color c2, float t)
    {
        return Color.FromArgb(Lerp(c1.R, c2.R, t), Lerp(c1.G, c2.G, t), Lerp(c1.B, c2.B, t));
    }
    public float Lerp(int a, int b, float t)
    {
            float tp = 1f - t;
            return (int)(tp * a + t * b);
    }
