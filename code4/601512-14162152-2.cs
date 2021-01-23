        public CoolControl()
        {
            InitalizeComponent();
            SetValue(ColorProperty, Colors.Red); // or any default color
        }
        public static DependencyProperty ColorProperty = DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(CoolControl)); // replace CoolControl with the name of your UserControl
        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }
