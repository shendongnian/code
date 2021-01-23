        public static Style CreateStyle(Type target, params (BindableProperty property, object value)[] setters)
        {
            Style style = new Style(target);
            style.ApplyToDerivedTypes = true;
            foreach (var setter in setters)
            {
                style.Setters.Add(new Setter
                {
                    Property = setter.property,
                    Value = setter.value
                });
            }
            return style;
        }
        public static void SetStyle(Type target, params (BindableProperty property, object value)[] setters)
        {
            Style style = new Style(target);
            style.ApplyToDerivedTypes = true;
            foreach (var setter in setters)
            {
                style.Setters.Add(new Setter
                {
                    Property = setter.property,
                    Value = setter.value
                });
            }
            Application.Current.Resources.Add(style);
        }
