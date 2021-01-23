    void Main()
    {
        var brush = KnownBrush(Color.FromArgb(255, 0, 0));
        brush.Dump();
    }
    
    private static Dictionary<Tuple<byte, byte, byte, byte>, SolidBrush> _KnownBrushes;
    public static SolidBrush KnownBrush(Color color)
    {
        if (_KnownBrushes == null)
        {
            _KnownBrushes = new Dictionary<Tuple<byte, byte, byte, byte>, SolidBrush>();
            foreach (var propertyInfo in typeof(Brushes).GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(Brush))
                {
                    var brush = propertyInfo.GetValue(null) as SolidBrush; // not a typo
                    if (brush != null)
                        _KnownBrushes[Tuple.Create(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A)] = brush;
                }
            }
        }
        
        SolidBrush result;
        _KnownBrushes.TryGetValue(Tuple.Create(color.R, color.G, color.B, color.A), out result);
        return result;
    }
