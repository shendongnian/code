    public abstract class CollectionFilterBase<T> : ICollectionViewFilter<T> where T : class
        {
            private readonly Dictionary<string, string> filters = new Dictionary<string, string>(10);
            private readonly MemberInfo[] properties;
            
            protected CollectionFilterBase()
            {
                 properties = typeof(T).GetProperties();
            }        
    
            protected void AddFilter(string memberName, string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    filters.Remove(memberName);
                    return;
                }
    
                filters[memberName] = value;
            }
            public bool FilterObject(T objectToFilter)
            {
                 foreach (var filterValue in filters)
                 {
                     var property = properties.SingleOrDefault(x => x.Name == filterValue.Key);
                     if(property == null)
                         return false;
                     
                     var propertyValue = property.GetValue(objectToFilter, null);
                     var stringValue = propertyValue == null ? null : propertyValue.ToString(); // or use string.Empty instead of null, depends what you're going to do with it.
                     // Now you have the property value and you have your 'filter' value in filterValue.Value, do the check, return false if it's not what you're looking for.
                     //The filter will run through all selected (non-empty) filters and if all of them check out, it will return true.
                 }
    
                return true;
            }
      }
