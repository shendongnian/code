        public static readonly DependencyProperty PassColorProperty =  DependencyProperty.Register("PassColor",
            typeof(string),
            typeof(ColorMasking),
            new PropertyMetadata("#FFCCFF"));
        public string PassColor
        {
            get { return (string)GetValue(PassColorProperty); }
            set { SetValue(PassColorProperty, value); }
        }
