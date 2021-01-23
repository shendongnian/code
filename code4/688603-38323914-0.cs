    public static IEqualityComparer GetEqualityComparer(this NameObjectCollectionBase nameObjectCollection)
      {
      PropertyInfo propertyInfo = typeof(NameObjectCollectionBase).GetProperty("Comparer", BindingFlags.Instance | BindingFlags.NonPublic);
      return (IEqualityComparer)propertyInfo.GetValue(nameObjectCollection);
      }
    
    public static IEqualityComparer<string> GetEqualityComparer(this NameValueCollection nameValueCollection)
      {
      return (IEqualityComparer<string>)((NameObjectCollectionBase)nameValueCollection).GetEqualityComparer();
      }
    
    public static Dictionary<string, string> ToDictionary(this NameValueCollection nameValueCollection)
      {
      Dictionary<string, string> dictionary =
        nameValueCollection.AllKeys.ToDictionary(x => x, x => nameValueCollection[x], nameValueCollection.GetEqualityComparer());
      return dictionary;
      }
