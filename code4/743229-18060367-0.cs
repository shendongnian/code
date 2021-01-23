        public static readonly DependencyProperty FirstStringProperty = DependencyProperty.Register(
            "FirstString", typeof(string), typeof(NAMEOFTHEPAGEORCONTROL), new PropertyMetadata("default value"));
        public string FirstString
        {
            get { return (string)GetValue(FirstStringProperty); }
            set { SetValue(FirstStringProperty, value); }
        }
