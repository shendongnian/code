        private static void SetPropertyValue(object parent, string propertyName, object value)
        {
            var inherType = parent.GetType();
            while (inherType != null)
            {
                PropertyInfo propToSet = inherType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (propToSet != null && propToSet.CanWrite)
                {
                    propToSet.SetValue(parent, value, null);
                    break;
                }
                inherType = inherType.BaseType;
            }
        }
