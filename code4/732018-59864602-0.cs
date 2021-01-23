    public static class ColorExtensions
    {
        ...
        public static Color WithA(this Color color, int newA) => Color.FromArgb(newA,color);
    }
        
