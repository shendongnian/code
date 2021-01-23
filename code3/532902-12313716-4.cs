    public static class ListExtensions
    {
        public static object ConvertToArray(this IList collection)
        {
            // guess type
            Type type;
            if (collection.GetType().IsGenericType && collection.GetType().GetGenericArguments().Length == 0)
                type = collection.GetType().GetGenericArguments()[0];
            else if (collection.Count > 0)
                type = collection[0].GetType();
            else
                throw new NotSupportedException("Failed to identify collection type for: " + collection.GetType());
            var array = (object[])Array.CreateInstance(type, collection.Count);
            for (int i = 0; i < array.Length; ++i)
                array[i] = collection[i];
            return array;
        }
        public static object ConvertToArray(this IList collection, Type arrayType)
        {
            var array = (object[])Array.CreateInstance(arrayType, collection.Count);
            for (int i = 0; i < array.Length; ++i)
            {
                var obj = collection[i];
                // if it's not castable, try to convert it
                if (!arrayType.IsInstanceOfType(obj))
                    obj = Convert.ChangeType(obj, arrayType);
                array[i] = obj;
            }
                
            return array;
        }
    }
