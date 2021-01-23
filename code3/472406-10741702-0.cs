    static class ObjectValidator
    {
        public static bool IsValid(object toValidate)
        {
            Type type = toValidate.GetType();
            var properties = type.GetProperties();
            foreach(var propInfo in properties)
            {
                var required = propInfo.GetCustomAttributes(typeof(RequiredAttribute), false);
                if (required.Length > 0)
                {
                    var value = propInfo.GetValue(toValidate, null);
                    // Here you'll need to expand the tests if you want for types like string
                    if (value == default(propInfo.PropertyType))
                        return false;
                }
            }
            return true;
        }
    }
