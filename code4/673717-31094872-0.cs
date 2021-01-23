        private List<Color> GetAllColors()
        {
            List<Color> allColors = new List<Color>();
            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    allColors.Add((Color)property.GetValue(null));
                }
            }
            return allColors;
        }
