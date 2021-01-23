    public static class SerializationExtensions
    {
        public static void UpdateChildReferences(this object input)
        {
            var hashDictionary = new Dictionary<int, object>();
            hashDictionary.Add(input.GetHashCode(), input);
            var props = input.GetType().GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.PropertyType.GetInterfaces()
                    .Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    var instanceTypesInList = propertyInfo.PropertyType.GetGenericArguments();
                    if(instanceTypesInList.Length != 1)
                        continue;
                    if (instanceTypesInList[0].IsSubclassOf(typeof(Entity)))
                    {
                        var list = (IList)propertyInfo.GetValue(input, null);
                        foreach (object t in list)
                        {
                            UpdateReferenceToParent(input, t);
                            UpdateChildReferences(t);
                        }
                    }
                }
            }
        }
        private static void UpdateReferenceToParent(object parent, object item)
        {
            var props = item.GetType().GetProperties();
            var result = props.FirstOrDefault(x => x.PropertyType == parent.GetType());
            if (result != null)
                result.SetValue(item, parent, null);
        }
    }
