    public static class ColorExtensions
    {        
        public static Color WithAlpha(this Color color, double opacity) 
        {
            byte op = (byte)(opacity*255);
            return Color.FromArgb(op, color.R, color.G, color.B);
        }
    }
    Color transparentblue = Color.Blue.WithAlpha(0.5);
