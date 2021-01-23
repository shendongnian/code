        private Color StringToColor(string colorName)
        {
            string xaml = string.Format("<Color xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">{0}</Color>", colorName);
            try { return (Color)XamlReader.Load(xaml); }
            catch { return Colors.Transparent; }
        }
