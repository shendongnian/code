        public static Dictionary<string, string> ObjectToDictionary(object value)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (value != null)
            {
                foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(value))
                {
                    if(descriptor != null && descriptor.Name != null)
                    {
                         object propValue = descriptor.GetValue(value);
                         if(propValue != null)
                              dictionary.Add(descriptor.Name,String.Format("{0}",propValue));
                }
            }
            return dictionary;
        }
