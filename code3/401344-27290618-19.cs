            private void SetProperty(String propertyName, object value)
            {
                var property = this.GetType().GetProperty(propertyName);
                if (property != null)
                    property.SetValue(this, value);
            }
            private void ParseArguments(ConstructorArgs args)
            {
                var properties = args.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    this.SetProperty(propertyInfo.Name, 
                       args.GetType().GetProperty(propertyInfo.Name).GetValue(args));
                }
            }
