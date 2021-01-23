    public class MultiLevelDistinctEntityTransformer : IResultTransformer
    {
        private readonly Dictionary<Type, List<String>> _fetchedCollectionProperties; // used to know which properties are fetched so you don't fetch more details than required
        public MultiLevelDistinctEntityTransformer(Dictionary<Type, List<String>> fetchedCollectionProperties)
        {
            _fetchedCollectionProperties = fetchedCollectionProperties;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return tuple.Last();
        }
         
        public IList TransformList(IList list)
        {
            if (list.Count == 0)
                return list;
            var result = (IList) Activator.CreateInstance(list.GetType());
            var distinctSet = new HashSet<Entity>();
            foreach (object item in list)
            {
                var entity = item as Entity; // Entity is the base class of my nhibernate classes
                if (entity == null)
                    continue;
                if (distinctSet.Add(entity))
                {
                    result.Add(item);
                    HandleItemDetails(item);
                }
            }
            return result;
        }
        private void HandleItemDetails(object item)
        {
            IEnumerable<PropertyInfo> collectionProperties =
                item.GetType().GetProperties().Where(
                    prop =>
                    prop.IsCollectionProperty()/*extension method which checks if the object inherits from ICollection*/ &&
                    _fetchedCollectionProperties.ContainsKey(item.GetType()) &&// get only the fetched details
                    _fetchedCollectionProperties[item.GetType()].Contains(prop.Name));
            foreach (PropertyInfo collectionProperty in collectionProperties)
            {
                dynamic detailList = collectionProperty.GetValue(item, null);
                if (detailList != null)
                {
                    dynamic uniqueValues =
                        Activator.CreateInstance(
                            typeof (List<>).MakeGenericType(collectionProperty.PropertyType.GetGenericArguments()[0]));
                    var distinct = new HashSet<Entity>();
                    foreach (var subItem in detailList)
                    {
                        var entity = subItem as Entity;
                        if (distinct.Add(entity))
                        {
                            uniqueValues.Add(subItem);
                            HandleItemDetails(subItem);
                        }
                    }
                    collectionProperty.SetValue(item, uniqueValues, null);
                }
            }
        }
    }
