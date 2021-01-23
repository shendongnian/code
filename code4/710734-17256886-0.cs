    internal class PropertyComparer
    {    
        public static IEnumerable<Difference<T>> GetDifferences<T>(PropertyComparer pc,
                                                                   IEnumerable<T> oldPersons,
                                                                   IEnumerable<T> newPersons)
            where T : Person
        {
            Dictionary<string, T> newPersonMap = newPersons.ToDictionary(p => p.Name, p => p);
            foreach (T op in oldPersons)
            {
                // match items from the two lists by the 'Name' property
                if (newPersonMap.ContainsKey(op.Name))
                {
                    T np = newPersonMap[op.Name];
                    Difference<T> diff = pc.SearchDifferences(op, np);
                    if (diff != null)
                    {
                        yield return diff;
                    }
                }
            }
        }
    
        private Difference<T> SearchDifferences<T>(T obj1, T obj2)
        {
            CacheObject(obj1);
            CacheObject(obj2);
            return SimpleSearch(obj1, obj2);
        }
    
        private Difference<T> SimpleSearch<T>(T obj1, T obj2)
        {
            Difference<T> diff = new Difference<T>
                                    {
                                        ChangedProperties = new List<string>(),
                                        OldPerson = obj1,
                                        NewPerson = obj2
                                    };
            ObjectAccessor obj1Getter = ObjectAccessor.Create(obj1);
            ObjectAccessor obj2Getter = ObjectAccessor.Create(obj2);
            var propertyList = _propertyCache[obj1.GetType()];
            // find the common properties if types differ
            if (obj1.GetType() != obj2.GetType())
            {
                propertyList = propertyList.Intersect(_propertyCache[obj2.GetType()]).ToList();
            }
            foreach (string propName in propertyList)
            {
                // fetch the property value via the ObjectAccessor
                if (!obj1Getter[propName].Equals(obj2Getter[propName]))
                {
                    diff.ChangedProperties.Add(propName);
                }
            }
            return diff.ChangedProperties.Count > 0 ? diff : null;
        }
        // cache for the expensive reflections calls
        private Dictionary<Type, List<string>> _propertyCache = new Dictionary<Type, List<string>>();
        private void CacheObject<T>(T obj)
        {
            if (!_propertyCache.ContainsKey(obj.GetType()))
            {
                _propertyCache[obj.GetType()] = new List<string>();
                _propertyCache[obj.GetType()].AddRange(obj.GetType().GetProperties().Select(pi => pi.Name));
            }
        }
    }
