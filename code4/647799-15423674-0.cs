            var propertyMap = new Dictionary<string, object>();
            // backup properties
            foreach (var propertyInfo in Properties.Settings.Default.GetType().GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.GetCustomAttributes(typeof(UserScopedSettingAttribute), false).Any())
                {
                    var name = propertyInfo.Name;
                    var value = propertyInfo.GetValue(Properties.Settings.Default, null);
                    propertyMap.Add(name, value);
                }
            }
            // restore properties
            foreach (var propertyInfo in Properties.Settings.Default.GetType().GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.GetCustomAttributes(typeof(UserScopedSettingAttribute), false).Any())
                {
                    var value = propertyMap[propertyInfo.Name];
                    propertyInfo.SetValue(Properties.Settings.Default, value, null);                    
                }
            }
