        public static DependencyProperty NameProperty = DependencyProperty.Register(
        "Name",
        typeof(string),
        typeof(PersonNameControl));
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }
