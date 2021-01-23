    foreach(T item in DataSource)
    {
          MyClass<T> m = new MyClass<T>()
          foreach (KeyValuePair<String, Func<T, String>> pair in m.AttributesUsing)
          { 
                m.Attributes = new Dictionary<String, String>();
                m.Attributes.Add(pair.Key, pair.Value(item));
          }
    }
