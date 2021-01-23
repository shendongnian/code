        private void TrySetProperty(object obj, string property, object value) {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if(prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }
