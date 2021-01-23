    public static IDictionary<TKey,TValue> LoadProperty<TKey,TValue>(this EntityObject entity, string name) {
        EntityObjectProperty prop = entity.Properties.Single(x => x.Name.Equals(name));
        var dict = new Dictionary<TKey,TValue>();
        dict.Add((TKey)prop.Name, TValue(prop.Value));
        return dict;
    }
