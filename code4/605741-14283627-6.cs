    class ThreeKeysDict<T1,T2,T3>
    {
       var dict1 = new Dictionary<T1,Tuple<T2,T3>>();
       var dict2 = new Dictionary<T2,Tuple<T1,T3>>();
       var dict3 = new Dictionary<T3,Tuple<T1,T2>>();
       public void Add(T1 key1,T2 key2, T3 key3)
       {
          dict1.Add(key1,Tuple.Create(key2,key3));
          dict2.Add(key2,Tuple.Create(key1,key3));
          dict3.Add(key3,Tuple.Create(key1,key2));
       }
       public Tuple<T2,T3> GetByKe1(T1 key1)
       {
          return dict1[key1];
       }
       public Tuple<T1,T3> GetByKe1(T2 key2)
       {
          return dict2[key2];
       }
       public Tuple<T1,T2> GetByKe1(T3 key3)
       {
          return dict3[key3];
       }
    }
