    public static class ColorHelper
    {
        public static Color Copy(this Color color)
        {
            if (color.IsKnownColor)
                return Color.FromKnownColor(color.ToKnownColor());
    
            if (color.IsNamedColor)
                return Color.FromName(color.Name);
            // this is better, then pass A,r,g,b separately
            return Color.FromArgb(color.ToArgb()); 
        }
