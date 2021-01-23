        public static DependencyProperty ColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(CoolControl)); // replace CoolControl with the name of your UserControl
        public Color BackgroundColor
        {
            get
            {
                var colorValue = GetValue(ColorProperty) as Color?; // Check that property has been set
                return colorValue.HasValue ? colorValue.Value : Colors.Red; // You can put whatever default color you want here
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }
