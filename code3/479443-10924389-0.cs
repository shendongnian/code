    var colors = typeof(Colors)
        .GetProperties(BindingFlags.Static | BindingFlags.Public)
        .ToDictionary(p => p.Name,
                      p => new SolidColorBrush((Color)p.GetValue(null, null))
                     );
