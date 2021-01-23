    Random rnd = new Random();
  
    private Color GetRandomColour()
    {
        var colorProperties = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public);
        var colors = colorProperties.Select(prop => (Color)prop.GetValue(null, null));
   
        int index = rnd.Next(colors.Count());
        return colors.ElementAt(index);
    }
