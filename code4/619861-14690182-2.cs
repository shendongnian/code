        public override SettingsPropertyValueCollection GetPropertyValues(
            SettingsContext context,
            SettingsPropertyCollection collection)
        {
            var spvc = new SettingsPropertyValueCollection();
            foreach (SettingsProperty item in collection)
            {
                var sp = new SettingsProperty(item);
                var spv = new SettingsPropertyValue(item);
                spv.SerializedValue = _mySettings[item.Name];
                spv.PropertyValue = _mySettings[item.Name];
                spvc.Add(spv);
            }
            return spvc;
        }
