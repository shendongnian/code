    var colors = typeof(Colors)
        .GetProperties(BindingFlags.Static | BindingFlags.Public)
        .Select(p => new ColorItem()
                     {
                         Name = p.Name,
                         Brush = new SolidColorBrush((Color)p.GetValue(null, null))
                     }
               ).ToList();
