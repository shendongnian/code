    public static readonly DependencyProperty RadiusProperty =
        DependencyProperty.Register("Radius", typeof(double), typeof(CircleArea), new FrameworkPropertyMetadata(0.0, OnRadiusChanged))
        private static void OnRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
             Area = Radius * Radius * Math.PI;
        }
    
        private static readonly DependencyPropertyKey AreaKey=
            DependencyProperty.RegisterReadOnly("Area", typeof(double)...
        public static readonly DependencyProperty AreaProperty = AreaKey.DependencyProperty;
        public Double Area
        {
            get
            {
                return (Double)GetValue(AreaProperty);
            }
            private set
            {
                SetValue(AreaKey, value);
            }
        }
