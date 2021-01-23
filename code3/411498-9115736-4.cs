        public static Dictionary<string, string> ObjectToDictionary(object value)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (value != null)
            {
                foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(value))
                {
                    dictionary.Add(descriptor.Name,descriptor.GetValue(value).ToString());
                }
            }
            return dictionary;
        }
