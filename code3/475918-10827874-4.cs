            Type t = typeof(Colors);
            var properties = t.GetProperties();
            List<ColorItem> items = new List<ColorItem>();
            
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                items.Add(new ColorItem
                {
                    Name = property.Name,
                    Color = new SolidColorBrush((Color)property.GetValue(null, null))
                });
            }
