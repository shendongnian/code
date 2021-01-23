     public static object GetEntityFieldValue(this object entityObj, string propertyName)
            {
                var pro = entityObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).First(x => x.Name == propertyName);
                return pro.GetValue(entityObj, null);
    
            }
     public static IEnumerable<PropertyInfo> GetManyRelatedEntityNavigatorProperties<T>()
            {
                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanWrite && x.GetGetMethod().IsVirtual && x.PropertyType.IsGenericType == true);
                return props;
            }
    public static bool HasAnyRelation(object entityObj)
            {
            
                    var collectionProps= GetManyRelatedEntityNavigatorProperties<AccountingCoding>();
    
                   
                    foreach (var item in collectionProps)
                    {
                        var collectionValue = GetEntityFieldValue(entityObj,item.Name);
                        if (collectionValue != null && collectionValue is IEnumerable)
                        {
                            var col = collectionValue as IEnumerable;
                            if (col.GetEnumerator().MoveNext())
                            {
                                return true;
                            }
    
                        }
                    }
                   return false;
    }
