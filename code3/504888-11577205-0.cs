        public static void MyMethod(object obj)
        {
            if (typeof(IDictionary).IsAssignableFrom(obj.GetType()))
            {
                Dictionary<object, object> dict = ((IDictionary)obj).Cast<dynamic>().ToDictionary(entry => entry.Key, entry => entry.Value);
                
                Type[] myTypes = dict.GetType().GetGenericArguments();
                //Type[0] - Type of keys
                //Type[1] - Type of values
            }
            else
            {
                // My object is not a dictionary
            }
        }
