    public class MyDictionary<T>
    {
        Dictionary<string, T> dict;
        public MyDictionary()
        {
            dict = new Dictionary<string, T>();
        }
        public T this[string name]
        {
            get
            {
                if (dict.ContainsKey(name))
                    return dict[name];
                else
                    return default(T);//or throw
            }
            set
            {
                dict[name] = value;
            }
        }
    }
