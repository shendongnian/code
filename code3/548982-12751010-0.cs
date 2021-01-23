    Dictionary<string, Windows.UI.Color> Colors()
    {
        var _Colors = typeof(Windows.UI.Colors)
            // using System.Reflection;
            .GetRuntimeProperties()
            .Select(c => new
            {
                Color = (Windows.UI.Color)c.GetValue(null),
                Name = c.Name
            });
        return _Colors.ToDictionary(x => x.Name, x => x.Color);
    }
