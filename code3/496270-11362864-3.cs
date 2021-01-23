    public static T LoadProperty<T,TKey,TValue>(this EntityObject entity, string name) 
        where T : IDictionary<TKey,TValue>, new() {
        EntityObjectProperty prop = entity.Properties.Single(x => x.Name.Equals(name));
        T t = new T();
        t.Add((TKey)prop.Name, TValue(prop.Value));
        return t;
    }
