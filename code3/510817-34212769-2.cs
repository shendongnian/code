    public string GetNameOfColor(Color color) {
        var colorProperty = typeof(Colors).GetProperties().FirstOrDefault(p =>
            (Color)(p.GetValue(p, null)) == color);
        return (colorProperty != null) ? colorProperty.Name : color.ToString();
    }
