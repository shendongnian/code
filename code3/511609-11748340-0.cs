    GetApproximateColorName(ColorTranslator.FromHtml(source))
    private static readonly IEnumerable<PropertyInfo> _colorProperties = typeof(Color)
                                                            .GetProperties(BindingFlags.Public | BindingFlags.Static)
                                                            .Where(p => p.PropertyType == typeof (Color));
        
    static string GetApproximateColorName(Color color)
    {
        int minDistance = int.MaxValue;
        string minColor = Color.Black.Name;
        foreach (var colorProperty in _colorProperties)
        {
            var colorPropertyValue = (Color)colorProperty.GetValue(null, null);
            if (colorPropertyValue.R == color.R
                    && colorPropertyValue.G == color.G
                    && colorPropertyValue.B == color.B)
            {
                return colorPropertyValue.Name;
            }
            int distance = Math.Abs(colorPropertyValue.R - color.R) +
                            Math.Abs(colorPropertyValue.G - color.G) +
                            Math.Abs(colorPropertyValue.B - color.B);
            if (distance < minDistance)
            {
                minDistance = distance;
                minColor = colorPropertyValue.Name;
            }
        }
        return minColor;
    }
