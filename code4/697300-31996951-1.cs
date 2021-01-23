    internal static class ColorExtensions
    {
        internal static Color ConvertToWindowsColor(this acColor.Color acColor)
        {
            return Color.FromArgb(acColor.ColorValue.ToArgb());
        }
        internal static acColor.Color ConvertToAutoCADColor(this Color winColor)
        {
            return acColor.Color.FromRgb(winColor.R, winColor.G, winColor.B);
        }
    }
