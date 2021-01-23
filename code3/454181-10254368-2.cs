    public Color GetColor(string colorName)
    {
      Color color = Colors.None;
      if (this.colormap.TryGetValue(colorName, out color));
      return color;
    }
